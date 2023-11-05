using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public CenterTextChanged centerTextChanged;

    public MouseSelectedObject mouseSelectedObject;

    public WaveController waveController;

    public LevelState state;

    public Transform startPoint;
    public Transform[] path;

    public Transform[] pathOne;
    public Transform[] pathTwo;
    public Transform[] pathThree;
    public Transform[] pathFour;
    public Transform[] pathFive;

    public GameObject[] hearts;

    private int lives;
    public int Lives
    {
        get { return lives; }
        set { lives = value; }
    }

    private int currency;
    public int Currency
    {
        get { return currency; }
        set { currency = value; }
    }

    private int stone;
    public int Stone
    {
        get { return stone; }
        set { stone = value; }
    }

    private int wood;
    public int Wood
    {
        get { return wood; }
        set { wood = value; }
    }

    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        ResetResources();
        ResetHearts();
    }

    public void EliminateHearth()
    {
        waveController.losedHearts += 1;
        Lives--;
        if (Lives > 0)
        {
            hearts[Lives].SetActive(false);
        }
        else
        {
            hearts[0].SetActive(false);
            centerTextChanged.YouLose();
            centerTextChanged.gameObject.SetActive(true);
            waveController.Restart();
            state = LevelState.Lose;
            DestruirGameObjectsPorTag(tagObjetosADestruir);
        }
    }

    public string tagObjetosADestruir = "Enemie"; 

    // Función para destruir GameObjects por tag.
    public void DestruirGameObjectsPorTag(string tag)
    {
        GameObject[] objetosADestruir = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject objeto in objetosADestruir)
        {
            Destroy(objeto);
        }
    }

    public void ResetHearts()
    {
        Lives = hearts.Length;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(true);
        }
        state = LevelState.Win;
    }

    public bool SpendResources(int spendCurrency, int spendStone, int spendWood)
    {
        if (Currency >= spendCurrency && Stone >= spendStone && Wood >= spendWood)
        {
            Currency -= spendCurrency;
            Stone -= spendStone;
            Wood -= spendWood;
            return true;
        }
        else
        {
            Debug.Log("Not enough resources to make this purchase.");
            return false;
        }
    }

    public enum LevelState
    {
        Win,
        Lose,
        Playing
    }

    private void ResetResources()
    {
        Currency = 1000;
        Stone = 50;
        Wood = 50;
    }
}
