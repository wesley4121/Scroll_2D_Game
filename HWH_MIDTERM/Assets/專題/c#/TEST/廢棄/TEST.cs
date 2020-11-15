using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TEST : MonoBehaviour
{
    // Start is called before the first frame update

   [SerializeField] public bool ZZZ = TESTX.XXX;
    public bool ZZZZ;
    public static bool YYYY = false;

    public GameObject TESTXXX;

    void Start()
    {
        TESTX.XXX = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TESTX.XXX = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            YYYY = false;
        }

    }
}
