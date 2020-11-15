using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class REMOVE : MonoBehaviour
{
    public static Flowchart s_PlayerFlowChartMoveSwitch;
    public bool PlayerRun;
    public float PlayerMoveBanlance;
    private Vector2 moveDir;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_animator;
    private Rigidbody2D m_rigidbody2D;
    public float jumpforce;
    public float movespeed;
    public bool isgrounded = false;
    public GameObject groundedObject;
    public GameObject m_idle;
    public GameObject m_walk;
    private void Awake()
    {
        s_PlayerFlowChartMoveSwitch = GameObject.Find("對話控制").GetComponent<Flowchart>();
    }
    void Start()
    {
        
        movespeed = 1;
        jumpforce = 0;
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
       
    }
    public static bool istalk
    {
        get { return s_PlayerFlowChartMoveSwitch.GetBooleanVariable("對話中"); }
    }
    void Update()
    {

            m_animator.SetBool("grounded", isgrounded);

        if (PlayerRun)
        {

        }
        if(!istalk)//對話控制
        {
            m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                m_rigidbody2D.AddForce(Vector2.up * jumpforce);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveDir.x = movespeed;
                m_animator.SetFloat("movespeed", 1);
                m_spriteRenderer.flipX = true;
            }

            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                PlayerRun = true;
                PlayerMoveBanlance += 0.1f;
                moveDir.x = movespeed * 3F;
                m_animator.SetFloat("run", 1);
                m_spriteRenderer.flipX = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveDir.x = -movespeed;
                m_animator.SetFloat("movespeed", 1);
                m_spriteRenderer.flipX = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                PlayerRun = true;
                PlayerMoveBanlance += 0.1f;
                moveDir.x = -movespeed * 3F;
                m_animator.SetFloat("run", 1);
                m_spriteRenderer.flipX = false;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                m_animator.SetFloat("run", 0);
                m_animator.SetFloat("movespeed", 0);
                PlayerMoveBanlance = 0;
                moveDir = Vector2.zero;
                
                
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                m_animator.SetFloat("run", 0);
                PlayerRun = false;
            }

        }
        else
        {
            m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            moveDir.x = 0;
        }
        moveDir.y = m_rigidbody2D.velocity.y;
        m_rigidbody2D.velocity = moveDir;
        
    }
    private void OnCollisionStay2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            foreach (ContactPoint2D element in collision.contacts)
            {
                if (element.normal.y > 0.25f)
                {
                    isgrounded = true;
                    groundedObject = collision.gameObject;
                    break;
                }
            }
        }
    }
    private void OnCollisionExit2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject == groundedObject)
        {
            m_animator.SetTrigger("jump");
            groundedObject = null;
            isgrounded = false;
        }
    }
}
