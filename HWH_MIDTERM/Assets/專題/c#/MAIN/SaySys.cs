using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaySys : MonoBehaviour
{
    public Text textlabel;
    public Image faceImage;
    [Header("文本")]
    public TextAsset textfile;
    public int index;
    public float textSpeed;
    public bool textFinished;
    public Sprite face01, face02;
    List<string> textList = new List<string>();

    private void Awake()
    {
        GetTextFormFile(textfile);
        
    }
    private void OnEnable()
    {
        //textlabel.text = textList[index];
        //index++;
        StartCoroutine(SetTestUI());
        textFinished = true; 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z ) && textFinished)
        {
            //textlabel.text = textList[index];
            //index++;
            StartCoroutine(SetTestUI());
        }
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var linedata = file.text.Split('\n');
        foreach (var line in linedata)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTestUI()
    {
        textFinished = false;
        textlabel.text = "";
        if (textList[index].Contains("A"))
        {
            faceImage.sprite = face01;
            index++;
        }
        else if (textList[index].Contains("B"))
        {
            faceImage.sprite = face02;
            index++;
        }
        //switch (textList[index])
        //{
        //    case "A":
        //        faceImage.sprite = face01;
        //        index++;
        //        break;
        //    case "B":
        //        faceImage.sprite = face02;
        //        index++;
        //        break;
        //}
        for (int i = 0; i < textList[index].Length; i++)
        {
            textlabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }
}
