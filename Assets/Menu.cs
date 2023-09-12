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
        UpdateUI(); // Renombrado OnGUI() a UpdateUI()
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("OpenMenu", isMenuOpen);
    }

    private void UpdateUI()
    {
        // Actualiza los valores de la interfaz de usuario con los datos del LevelManager.
        currencyUI.text = LevelManager.main.Currency.ToString();
        currencyUI2.text = LevelManager.main.Currency.ToString();
        stoneUI.text = LevelManager.main.Stone.ToString();
        woodUI.text = LevelManager.main.Wood.ToString();
    }
}
