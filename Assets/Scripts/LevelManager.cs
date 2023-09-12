using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public CenterTextChanged centerTextChanged;

    public LevelState state;

    public Transform startPoint;
    public Transform[] path;

    public Transform[] pathOne;
    public Transform[] pathTwo;
    public Transform[] pathThree;
    public Transform[] pathFour;
    public Transform[] pathFive;

    public GameObject[] hearts;

    public int lives;

    public int currency;

    public int stone;

    public int wood;

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 1000;
        stone = 50;
        wood = 50;
        lives = 8;

    }

    public void EliminateHearth()
    {
        --lives;
        if(lives > 0)
        {
            hearts[lives].SetActive(false);
        }
        else
        {
            hearts[0].SetActive(false);
            centerTextChanged.YouLose();
            centerTextChanged.gameObject.SetActive(true);
            state = LevelState.Lose;
        }
        
    }

    public void ResetHearts()
    {
        lives = 8;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
            state = LevelState.Win;
        }
    } 

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendEverything(int spendCurrency, int spendStone, int spendWood)
    {
        if(SpendCurrency(spendCurrency) == true && SpendStone(spendStone) == true && SpendWood(spendWood) == true)
        {
            currency -= spendCurrency;
            stone -= spendStone;
            wood -= spendWood;
            return true;
        }
        else
        {
            return false;
        }   
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            
            return true;
        } else {
            Debug.Log("You do not have enough gold to purchase this item");
            return false;
        }
    }

    public bool SpendStone(int spendStone)
    {
        if(spendStone <= stone)
        {
            return true;
        } else {
            Debug.Log("You do not have enough stone to purchase this item");
            return false;
        }
    }

    public bool SpendWood(int spendWood)
    {
        if(spendWood <= wood)
        {
            
            return true;
        } else {
            Debug.Log("You do not have enough wood to purchase this item");
            return false;
        }
    }
    
    public enum LevelState
    {
        Win,
        Lose,
        Playing
    }
}
