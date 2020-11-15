using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACTIVE : MonoBehaviour
{
    public GameObject[] activeObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            for (int i = 0; i < activeObject.Length; i++)
            {
                activeObject[i].SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
