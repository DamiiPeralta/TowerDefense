using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour
{
    private Tower selectedTower; // La torre seleccionada para construir.
    private SpriteRenderer spriteRenderer;
    public Sprite constructionSprite; // Sprite de construcción
    public bool isDragging;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            OnDrag();
        }
        if (Input.GetMouseButtonDown(0))
        {
           OnEndDrag();
        }
    }

    public void TowerSelection()
    {
        // Cuando se hace clic en el botón del menú, seleccionamos la torre.
        selectedTower = BuildManager.main.GetSelectedTower();

        // Llama a SetConstructionMode con true para activar el sprite de construcción
        SetConstructionMode(true);
        Debug.Log("Pointer Down Event Triggered");
        isDragging = true; // Inicia el arrastre cuando se selecciona una torre.
    }

    public void OnDrag()
    {
        if (selectedTower == null)
            return;


        // Durante el arrastre, mueve una representación visual de la torre según la posición del cursor.
        MousePositionSprite();
    }

    void MousePositionSprite()
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

    public void OnEndDrag()
    {
        if (selectedTower == null)
            return;

        // Limpia la torre seleccionada después de soltarla.
        //BuildManager.main.SetSelectedTower(-1); // -1 o un valor que indique "ninguna torre seleccionada"
        isDragging = false; // Detiene el arrastre cuando se suelta la torre.
        SetConstructionMode(false);
    }

    private void SetConstructionMode(bool isConstructionMode)
    {
        if (isConstructionMode)
        {
            // Activa el sprite de construcción y establece el sprite de construcción
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = constructionSprite;
        }
        else
        {
            // Desactiva el sprite de construcción
            spriteRenderer.enabled = false;
        }
        // Activa o desactiva el GameObject en función del modo de construcción
    }
}
