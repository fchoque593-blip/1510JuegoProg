using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Detecta si presionas A/D o Flechas Izquierda/Derecha
        float movimientoX = Input.GetAxisRaw("Horizontal");

        // Aplica velocidad horizontal
        rb.linearVelocity = new Vector2(movimientoX * velocidad, rb.linearVelocity.y);

        // Giro del personaje según la dirección
        if (movimientoX > 0)
        {
            spriteRenderer.flipX = false; // Mira hacia la derecha
        }
        else if (movimientoX < 0)
        {
            spriteRenderer.flipX = true;  // Mira hacia la izquierda
        }
    }
}