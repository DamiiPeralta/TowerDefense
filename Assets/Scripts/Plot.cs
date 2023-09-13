using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private DragAndDropHandler dragAndDropHandler;
    
    private GameObject towerObj;

    public Turret turret;
    private Color startColor;

    private void Start()
    {
       startColor = sr.color;
    }

    private void OnMouseEnter() 
    {
        // Cambia el color del Plot cuando el mouse entra.
        sr.color = hoverColor;
    }

    private void OnMouseExit() 
    {
        // Restaura el color original del Plot cuando el mouse sale.
        sr.color = startColor;
    }

    public void OnMouseUp()
    {
        if(dragAndDropHandler.isDragging)
        {
            OnDrop();
        }
    }

    public void OnDrop()
    {
        // Se llama cuando una torre se suelta en el Plot.

        if (UIManager.main.IsHoveringUI()) 
            return;

        if (towerObj != null) 
        {
            // Si ya hay una torre en el Plot, puedes implementar la lógica de actualización o mejora aquí.
            return;
        }

        Tower selectedTower = BuildManager.main.GetSelectedTower();

        // Verifica si el Plot es válido para la construcción.
        if (IsEmpty() && LevelManager.main.SpendResources(selectedTower.cost, selectedTower.stoneCost, selectedTower.woodCost))
        {
            Debug.Log("Se construye la torre");
            // Construye la torre en el Plot.
            towerObj = Instantiate(selectedTower.prefab, transform.position, Quaternion.identity);
            turret = towerObj.GetComponent<Turret>();

            // Notifica al Turret que se ha colocado en este Plot.
            turret.OnTowerPlaced(this);

            // Aquí puedes realizar otras acciones si es necesario, como actualizar la interfaz de usuario.

            // Limpia la torre seleccionada después de soltarla.
        }
        else
        {
            // Aquí puedes mostrar un mensaje de error o realizar otras acciones si no se puede construir la torre.

            
        }
    }

    public bool IsEmpty()
    {
        Debug.Log("IsEmpty");
        // Verifica si la variable "turret" está configurada o no.
        return turret == null; // Si turret es null, el Plot está vacío; de lo contrario, no lo está.

    }

    public void OnTowerUpgraded()
    {
        // Realiza acciones específicas cuando la torre en este Plot ha sido mejorada.
        // Puedes cambiar la apariencia del Plot u otras acciones según tus necesidades.
    }
}
