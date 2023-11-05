using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerImageSelector : MonoBehaviour
{
    public GameObject towerPrefab;
    public MouseSelectedObject mouseSelectedObject;

    
    public void ConstructionOn()
    {
    mouseSelectedObject.tower = towerPrefab;
    
    if(towerPrefab.tag == "Turret")
    {

        mouseSelectedObject.SpriteRenderer.sprite = towerPrefab.GetComponent<Turret>().sprite;
        AdjustImage();

    }
    if(towerPrefab.tag == "FarmTile")
    {

        mouseSelectedObject.SpriteRenderer.sprite = towerPrefab.GetComponent<FarmTile>().sprite;
        AdjustImage();

    }
    if(towerPrefab.tag == "BombTile")
    {

        mouseSelectedObject.SpriteRenderer.sprite = towerPrefab.GetComponent<BombTile>().sprite;
        
        AdjustImage();

    }

    
    }
   public SpriteRenderer spriteRenderer;
   public Vector2 nuevoTamaño = new Vector2(1f, 1f); // Cambia estos valores según el tamaño deseado
   void AdjustImage()
   {
        spriteRenderer = mouseSelectedObject.SpriteRenderer;
       // Asegúrate de asignar el SpriteRenderer en el Inspector.
      //if (spriteRenderer == null)
      //{
      //    spriteRenderer = GetComponent<SpriteRenderer>();
      //
       // Cambia el tamaño del SpriteRenderer.
       spriteRenderer.size = nuevoTamaño;
   }

    //void OnMouseDown()
    //{
    //    Debug.Log("Funciona!");
    //    mouseSelectedObject.tower = towerPrefab;
    //    mouseSelectedObject.gameObject.GetComponent<Image>().sprite = towerPrefab.GetComponentInChildren<Image>().sprite;
    //    
    //}
 
}
