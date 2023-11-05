using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] public float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;

    private float baseSpeed;

    public bool checkpoint;

    public int newPath = 0;


    void Start()
    {
        baseSpeed = moveSpeed;
        target = LevelManager.main.path[pathIndex];
    }

    void Update()
    {
        
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if(!checkpoint)
            {
                if(pathIndex == LevelManager.main.path.Length)
                {
                    FindNewPath();
                    checkpoint = true;
                    pathIndex = -1;

                } else {
                target = LevelManager.main.path[pathIndex];
                }
            }else
            {
                
                if(pathIndex == LevelManager.main.pathOne.Length)
                {
                    
                    LevelManager.main.EliminateHearth(); 
                    Destroy(gameObject);
                    return;
                } else {

                    switch (newPath)
                    {
                    case 1:
                        target = LevelManager.main.pathOne[pathIndex];
                        break;
                    case 2:
                        target = LevelManager.main.pathTwo[pathIndex];
                        break;
                    case 3:
                        target = LevelManager.main.pathThree[pathIndex];
                        break;
                    case 4:
                        target = LevelManager.main.pathFour[pathIndex];
                        break;
                    case 5:
                        target = LevelManager.main.pathFive[pathIndex];
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Turret")
        {
            Destroy(other.gameObject);
        }    
    }

    public void FindNewPath()
    {
        newPath = Random.Range(1, 5);
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;

    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
