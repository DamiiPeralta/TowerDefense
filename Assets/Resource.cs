using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource : MonoBehaviour
{
    public MaterialToScavenge choose;
    public GameObject floatingText;
    public int health = 10;

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject, 3f);
        }
    }

    public void TakeHit(int toolHit)
    {
        health -= toolHit;
        Debug.Log(health);

        if (choose == MaterialToScavenge.Stone)
        {
            // Incrementa la piedra en LevelManager usando la propiedad pública.
            LevelManager.main.Stone += toolHit;
        }
        else if (choose == MaterialToScavenge.Wood)
        {
            // Incrementa la madera en LevelManager usando la propiedad pública.
            LevelManager.main.Wood += toolHit;
        }

        // Crea y muestra el texto flotante.
        ShowFloatingText("+" + toolHit + " " + choose);
    }

    private void ShowFloatingText(string text)
    {
        // Crea y muestra el texto flotante en la posición actual del recurso.
        GameObject floatingTextObj = Instantiate(floatingText, transform.position, Quaternion.identity);
        TextMeshProUGUI textMesh = floatingTextObj.GetComponent<TextMeshProUGUI>();
        
        if (textMesh != null)
        {
            textMesh.text = text;
        }

        // Destruye el objeto de texto flotante después de un tiempo.
        Destroy(floatingTextObj, 2.0f);
    }

    public enum MaterialToScavenge
    {
        Stone,
        Wood
    }
}
