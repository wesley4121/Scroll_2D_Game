using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IDLEANIMATE : MonoBehaviour
{

    private Animator m_animator;
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {

        m_animator = GetComponent<Animator>();
        m_transform = GetComponent<Transform>();

    }
    public static bool Walk
    {
        get { return MOVE.PlayerWalk; }
    }
    public static bool Run
    {
        get { return MOVE.PlayerRun; }
    }
    public static bool Idle
    {
        get { return MOVE.PlayerIdle; }
    }
    // Update is called once per frame
    void Update()
    {
        if (Idle)
        {
            m_transform.localScale = new Vector3(1, 1, 1);
            m_animator.SetFloat("idle", 1);
        }
        else
        {
            m_transform.localScale = new Vector3(0, 1, 1);
            m_animator.SetFloat("idle", 0);
        }

    }
}
