using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private MouseSelectedObject mouseSelectedObject;
    
    private GameObject towerObj;

    private Color startColor;

    private void Start()
    {
        mouseSelectedObject = LevelManager.main.mouseSelectedObject;    
        startColor = sr.color;
    }

    private void OnMouseEnter() 
    {
        // Cambia el color del Plot cuando el mouse entra.
        sr.color = hoverColor;
        mouseSelectedObject.plot = this;
    }

    private void OnMouseExit() 
    {
        // Restaura el color original del Plot cuando el mouse sale.
        sr.color = startColor;
        mouseSelectedObject.plot = null;
    }

    public void ConstructTower()
    {
        Debug.Log("paso check");
        if(towerObj == null)
        {
            if(mouseSelectedObject.tower != null)
            {
                OnDrop();
                
            }
        }
        
    }

    public void OnDrop()
    {
        towerObj = Instantiate(mouseSelectedObject.tower, transform.position, Quaternion.identity);

    }

    public void OnTowerUpgraded()
    {
        // Realiza acciones específicas cuando la torre en este Plot ha sido mejorada.
        // Puedes cambiar la apariencia del Plot u otras acciones según tus necesidades.
    }
}
