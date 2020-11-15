using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkAble : MonoBehaviour
{
    public GameObject c_penel;
    public GameObject c_talkIcon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        c_talkIcon.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        c_talkIcon.SetActive(false);
    }

    void Update()
    {
        if (c_talkIcon.activeSelf && Input.GetKey(KeyCode.Z))
        {
            c_penel.SetActive(true);
        }
    }
}
