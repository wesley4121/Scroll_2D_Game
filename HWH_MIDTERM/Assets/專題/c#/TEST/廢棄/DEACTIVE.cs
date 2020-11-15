using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEACTIVE : MonoBehaviour
{
    
    // Start is called before the first frame update
    void deACTIVE()
    {
        GameObject.Find("CM vcam3").SetActive(true);
    }
    void Start()
        
    {
        
        Invoke("deACTIVE", 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
