using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    [SerializeField] public GameObject deathAnim;
    //private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0)
        {
            Vector3 currentPosition = transform.position;
            LevelManager.main.Currency += currencyWorth;
            //isDestroyed = true;
            Destroy(gameObject);
            Instantiate(deathAnim, currentPosition, Quaternion.identity);
        }
    }
}

