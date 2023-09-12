using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSelectedObject : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public GameObject turretImage;
    public GameObject prefab;
    public bool isPlotSelected = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(prefab != null)
        {
            //image = 
        }
        
        MousePositionImage();
    }

    void MousePositionImage()
    {
        // Obtener la posición actual del cursor del mouse en coordenadas de pantalla
        Vector3 mousePositionScreen = Input.mousePosition;

        // Convertir la posición del mouse a coordenadas del mundo
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        // Mantener la misma altura del GameObject (por ejemplo, en el plano XY)
        mousePositionWorld.z = transform.position.z;

        // Actualizar la posición del GameObject para que siga al cursor
        transform.position = mousePositionWorld;
    
    }

    public void SelectedTower()
    {
        gameObject.SetActive(true);
        //prefab.gameObject.GetComponent
    }

    public void UnselectTower()
    {
        gameObject.SetActive(false);
        prefab = null;
    }

    public void OnMouseUp()
    {
        if(prefab != null && !isPlotSelected)
        {
            UnselectTower();
        }
    }

}
