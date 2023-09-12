using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Resource : MonoBehaviour
{
    public MaterialToScavange choose;
    public GameObject floatingText;
    public int health = 10;


    private void Update() 
    {
        if(health <= 0)
        {
            Destroy(gameObject, 3f);
        }
    }
    
    public void TakeHit(int toolHit)
    {
        health -= toolHit;
        Debug.Log(health);
        if(choose == MaterialToScavange.Stone)
        {
            LevelManager.main.stone += toolHit;
        }
        if(choose == MaterialToScavange.Wood)
        {
            LevelManager.main.wood += toolHit;
        }
        floatingText.gameObject.GetComponent<FloatingText>().ChangeText( "+" + toolHit + choose);
        Instantiate(floatingText, transform.position, Quaternion.identity);
        
    }

    public enum MaterialToScavange
    {
       Stone,
       Wood
    }
}



