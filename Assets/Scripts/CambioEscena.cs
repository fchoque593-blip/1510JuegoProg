using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class CambioEscena : MonoBehaviour
{
    [Tooltip("Escribe exactamente el nombre de la escena a la que lleva esta puerta")]
    public string nombreEscena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si lo que tocó la puerta fue el jugador
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nombreEscena);
        }
    }
}