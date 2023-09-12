using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI currencyUI2;
    [SerializeField] TextMeshProUGUI stoneUI;
    [SerializeField] TextMeshProUGUI woodUI;
    [SerializeField] Animator anim;

    private bool isMenuOpen = true;

    private void Update() 
    {
        OnGUI();    
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("OpenMenu", isMenuOpen);
    } 

    private void OnGUI() 
    {
        currencyUI.text = LevelManager.main.currency.ToString();
        currencyUI2.text = LevelManager.main.currency.ToString();
        stoneUI.text = LevelManager.main.stone.ToString();   
        woodUI.text = LevelManager.main.wood.ToString();       
    }
}
