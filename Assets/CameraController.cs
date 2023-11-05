using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float upperLimit = 10.0f; // Límite superior
    public float lowerLimit = 1.0f; // Límite inferior

    void Update()
    {
        // Mover la cámara verticalmente en respuesta a las teclas de flecha
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(0, verticalInput, 0);

        // Calcula la nueva posición de la cámara
        Vector3 newPosition = transform.position + moveDirection * moveSpeed * Time.deltaTime;

        // Limita la posición de la cámara dentro de los límites
        newPosition.y = Mathf.Clamp(newPosition.y, lowerLimit, upperLimit);

        // Aplica la nueva posición a la cámara
        transform.position = newPosition;
    }
}
