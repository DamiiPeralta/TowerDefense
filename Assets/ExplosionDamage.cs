using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] private int bulletDamage = 1;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
        Destroy(bullet);
    }
}