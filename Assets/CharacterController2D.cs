using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] GameObject misionSelectPanel;
    public bool open = false;
    
    public float animState;

    public bool lastTimeLeft;
    Rigidbody2D rigidbody2d;

    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    Animator animator;

    public GameObject[] camaras;

    public int key;
    public bool isWorking = false;

    public bool canWalk = true;


    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        camaras[0].SetActive(true);
        camaras[1].SetActive(false);
        camaras[2].SetActive(false);
        key = 2;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            open = !open;
            misionSelectPanel.GetComponent<MisionSelect>().SetInterfaz();
            misionSelectPanel.SetActive(open);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (key)
            {
                case 1:
                canWalk = true;
                camaras[0].SetActive(true);
                camaras[1].SetActive(false);
                camaras[2].SetActive(false);
                key = 2;
                break;
                case 2:
                canWalk = false;
                camaras[0].SetActive(false);
                camaras[1].SetActive(true);
                camaras[2].SetActive(false);
                key = 3;
                break;
                case 3:
                canWalk = false;
                camaras[0].SetActive(false);
                camaras[1].SetActive(false);
                camaras[2].SetActive(true);
                key = 1;
                break;
            }
            
        }
        if(canWalk)
        {
            
            animState = Input.GetAxisRaw("Horizontal");

            motionVector = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical")
                );
            //animator.SetFloat("horizontal", Input.GetAxisRaw("Horizontal"));

            AnimationSet();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!isWorking)
        {
            rigidbody2d.velocity = motionVector * speed;
        }
        else
        {
            Vector2 stayStill = new Vector2(0,0);
            rigidbody2d.velocity = stayStill;
        }
        
    }

    void AnimationSet()
    {
        if(isWorking)
        {
            if(animator.GetBool("idleLeft") == true)
            {
                animator.SetBool("toolL", true);
            }else if(animator.GetBool("idleRight") == true)
            {
                animator.SetBool("toolR", true);
            }
        }else
        {
            animator.SetBool("toolL", false);
            animator.SetBool("toolR", false);
        }
        if(animState == 0)
            {
                if(lastTimeLeft)
                {
                    animator.SetBool("idleLeft", true);
                    animator.SetBool("idleRight", false);
                    animator.SetBool("runLeft", false);
                    animator.SetBool("runRight", false);
                    
                }
                else
                {
                    animator.SetBool("idleLeft", false);
                    animator.SetBool("idleRight", true);
                    animator.SetBool("runLeft", false);
                    animator.SetBool("runRight", false);
                }
                if(Input.GetAxisRaw("Vertical") != 0 && lastTimeLeft)
                {
                    animator.SetBool("idleLeft", false);
                    animator.SetBool("idleRight", false);
                    animator.SetBool("runLeft", true);
                    animator.SetBool("runRight", false);
                }
                else if(Input.GetAxisRaw("Vertical") != 0 && !lastTimeLeft)
                {
                    animator.SetBool("idleLeft", false);
                    animator.SetBool("idleRight", false);
                    animator.SetBool("runLeft", false);
                    animator.SetBool("runRight", true);
                }
            }
            
        if(animState != 0)
        {
            
            if(animState > 0)
            {
                animator.SetBool("idleLeft", false);
                animator.SetBool("idleRight", false);
                animator.SetBool("runLeft", false);
                animator.SetBool("runRight", true);
                lastTimeLeft = false;
            }
            if(animState < 0)
            {
                animator.SetBool("idleLeft", false);
                animator.SetBool("idleRight", false);
                animator.SetBool("runLeft", true);
                animator.SetBool("runRight", false);
                lastTimeLeft = true;
            }
        }
    }
}
