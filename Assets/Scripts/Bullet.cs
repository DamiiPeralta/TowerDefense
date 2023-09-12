using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public TypeOfBullet typeOfBullet;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public GameObject explosion;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int bulletDamage = 1;

    private Transform target;

    private void Start() 
    {
        Destroy(gameObject, 2f);    
    }

    public void SetTarget(Transform _target) 
    {
        target = _target;
    }

    private void FixedUpdate() 
    {
        if(!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(typeOfBullet == TypeOfBullet.Normal)
        {
            other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        if(typeOfBullet == TypeOfBullet.Explosive)
        {
            explosion.SetActive(true);
        }
       
    }

    public enum TypeOfBullet
    {
        Normal,
        Explosive
    }
}
