using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class GM : MonoBehaviour
{
    public GameObject M_idle;
    private Animator i_animator;
    private Transform i_transform;
    public GameObject M_walk;
    private Animator w_animator;
    private Transform w_transform;
    public GameObject M_run;
    private Animator r_animator;
    private Transform r_transform;

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
        r_animator = M_run.GetComponent<Animator>();
        r_transform = M_run.GetComponent<Transform>();
    }
    private void Update()
    {
        if (Walk)
        {
            w_animator.SetFloat("walk", 1);
            w_transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            w_animator.SetFloat("walk", 0);
            w_transform.localScale = new Vector3(0, 0, 0);
        }

        if (Idle)
        {
            i_animator.SetFloat("idle", 1);
            i_transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            i_animator.SetFloat("idle", 0);
            i_transform.localScale = new Vector3(0, 0, 0);
        }
        if (Run)
        {
            r_animator.SetFloat("run", 1);
            r_transform.localScale = new Vector3(1, 1, 0);
        }
        else
        {
            r_animator.SetFloat("run", 0);
            r_transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
