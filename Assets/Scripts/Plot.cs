using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    public MouseSelectedObject mouseSelObj;
    
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambia el color del Plot cuando el cursor entra (utilizado para el sistema de arrastrar y soltar).
        sr.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Restaura el color original del Plot cuando el cursor sale (utilizado para el sistema de arrastrar y soltar).
        sr.color = startColor;
    }

    public void OnDrop(PointerEventData eventData)
{
    // Se llama cuando una torre se suelta en el Plot.

    if(UIManager.main.IsHoveringUI()) 
        return;

    if(towerObj != null) 
    {
        // Si ya hay una torre en el Plot, puedes implementar la lógica de actualización o mejora aquí.
        return;
    }

    Tower selectedTower = BuildManager.main.GetSelectedTower();

    // Verifica si el Plot es válido para la construcción.
    if (IsEmpty() && LevelManager.main.SpendResources(selectedTower.cost, selectedTower.stoneCost, selectedTower.woodCost))
    {
        // Construye la torre en el Plot.
        towerObj = Instantiate(selectedTower.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();

        // Aquí puedes realizar otras acciones si es necesario, como actualizar la interfaz de usuario.

        // Limpia la torre seleccionada después de soltarla.
        BuildManager.main.SetSelectedTower(-1); // -1 o un valor que indique "ninguna torre seleccionada".
    }
    else
    {
        // Aquí puedes mostrar un mensaje de error o realizar otras acciones si no se puede construir la torre.

        // Limpia la torre seleccionada después de soltarla.
        BuildManager.main.SetSelectedTower(-1); // -1 o un valor que indique "ninguna torre seleccionada".
    }
}


    public bool IsEmpty()
    {
        // Implementa la lógica para verificar si el Plot está vacío (sin torre).
        // Esto dependerá de cómo estás controlando si hay una torre en el Plot o no.
        // Debes retornar true si el Plot está vacío; de lo contrario, false.

        // Ejemplo:
        return turret == null; // Si la variable "turret" está vacía, el Plot está vacío.
    }
}
