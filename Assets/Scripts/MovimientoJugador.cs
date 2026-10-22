using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 entradas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detecta flechas / WASD tanto en X (izquierda/derecha) como en Y (arriba/abajo)
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");

        entradas = new Vector2(movX, movY).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = entradas * velocidad;
    }
}