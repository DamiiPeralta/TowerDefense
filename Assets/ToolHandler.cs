using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolHandler : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] GameObject tool;
    
    [SerializeField] public List<GameObject> tools;

    public Animator an;

    public CharacterController2D char2d;

    public GameObject resource;
    public bool canWork;

    public bool cooldown = true;

    public float workVelocity = 1;
    public float baseworkVelocity = 1;
    
    private bool isKeyPressed = false;
    
    public int workForce = 2;
    

    private void Start() 
    {

    } 
    private void Update() 
    {
        if(canWork && Input.GetKeyDown(KeyCode.F))
        {
            isKeyPressed = true;
            char2d.isWorking = true;
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            isKeyPressed = false;
            
            char2d.isWorking = false;
        }
        Working();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ResourceStone")
        {

            tool = tools[0];
            
            canWork = true;
            resource = other.gameObject;
        }
        if(other.tag == "ResourceWood")
        {
            tool = tools[1];
            
            canWork = true;
            resource = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "ResourceStone" || other.tag == "ResourceWood")
        {
            canWork = false;
            resource = null;
            if(tool != null)
            {
                tool.gameObject.SetActive(false);
            }
            
            tool = null;
            workVelocity = 0;
        }
        
    }

    public void Cooldown()
    {
        if(!cooldown && workVelocity > 0)
        {
            workVelocity -= Time.deltaTime;
        }
        if(!cooldown && workVelocity <= 0)
        {
            cooldown = true;
            workVelocity = baseworkVelocity;
        }
    }

    public void Working()
    {
        if(resource != null)
        {
            if(isKeyPressed)
            {
                if(cooldown)
                {
                    if(resource.GetComponent<Resource>().health <= 0)
                    {
                        
                        char2d.isWorking = false;
                        resource = null;
                    }else
                    {
                        tool.gameObject.SetActive(true);
                        
                        resource.GetComponent<Resource>().TakeHit(workForce);
                        cooldown = false;
                    }

                }else
                {
                    Cooldown();
                }
            }else
            {
                if(tool != null)
                {
                    tool.gameObject.SetActive(false);
                }
            }
        }else
        {
            canWork = false;
            resource = null;
            if(tool != null)
            { 
                tool.gameObject.SetActive(false);
            }
            tool = null;
            workVelocity = 0;
        }
        
    }
}

