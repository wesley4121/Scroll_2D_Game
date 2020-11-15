using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRIGGERCOIN : MonoBehaviour
{
    public AudioSource m_audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            Instantiate(m_audio,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        Debug.Log(collision.name);
    }
}
