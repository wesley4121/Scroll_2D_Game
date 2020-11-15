using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class GMold : MonoBehaviour
{
    public GameObject M_idle;
    private Animator i_animator;
    private Transform i_transform;
    public GameObject M_walk;
    private Animator w_animator;
    private Transform w_transform;

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

    private void Start()
    {
        i_animator = M_idle.GetComponent<Animator>();
        i_transform = M_idle.GetComponent<Transform>();
        w_animator = M_walk.GetComponent<Animator>();
        w_transform = M_walk.GetComponent<Transform>();
    }
    private void Update()
    {
        if (Walk)
        {
            w_animator.SetFloat("walk", 1);
        }
        else
        {
            w_animator.SetFloat("walk", 0);
        }

        if (Idle)
        {
            i_animator.SetFloat("idle", 1);
        }
        else
        {
            i_animator.SetFloat("idle", 0);
        }
    }
}
