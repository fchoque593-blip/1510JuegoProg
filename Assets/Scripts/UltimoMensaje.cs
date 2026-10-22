
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UltimoMensaje : MonoBehaviour
{
    public TMP_Text titulo;
    public TMP_Text textoPrueba;
    public TMP_Text temporizador;
    public TMP_Text textoMensaje;
    public TMP_Text textoProgreso;

    public TMP_InputField campoRespuesta;
    public Button botonComprobar;

    private int pruebaActual = 0;
    private float tiempoRestante;
    private bool juegoTerminado = false;

    private void Start()
    {
        botonComprobar.onClick.AddListener(ComprobarRespuesta);
        IniciarPrueba();
    }

    private void Update()
    {
        if (juegoTerminado) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 20;
            textoMensaje.text = "Se acabo el tiempo. Intentalo otra vez.";
            campoRespuesta.text = "";
        }

        temporizador.text =
            "TIEMPO: " + Mathf.CeilToInt(tiempoRestante);
    }

    private void IniciarPrueba()
    {
        juegoTerminado = false;
        campoRespuesta.interactable = true;
        botonComprobar.interactable = true;
        campoRespuesta.text = "";
        tiempoRestante = 20;

        textoMensaje.text = "";

        if (pruebaActual == 0)
        {
            titulo.text = "EL ULTIMO MENSAJE";
            textoPrueba.text =
                "PRUEBA 1\n\nEscribe exactamente esta frase:\n" +
                "NO TODO TERMINA AL DESPERTAR";

            textoProgreso.text = "PRUEBA 1 DE 3";
        }
        else if (pruebaActual == 1)
        {
            titulo.text = "LA SEGUNDA PISTA";
            textoPrueba.text =
                "PRUEBA 2\n\n" +
                "Te sigue cuando hay luz,\n" +
                "pero desaparece en la oscuridad.\n" +
                "¿Que eres?";

            textoProgreso.text = "PRUEBA 2 DE 3";
        }
        else if (pruebaActual == 2)
        {
            titulo.text = "LA CONTRASENA FINAL";
            textoPrueba.text =
                "PRUEBA 3\n\n" +
                "Tiene 8 letras y representa el momento\n" +
                "en que comienza un nuevo dia.\n" +
                "¿Que palabra es?";

            textoProgreso.text = "PRUEBA 3 DE 3";
        }

        temporizador.text = "TIEMPO: 20";
    }

    private void ComprobarRespuesta()
    {
        if (juegoTerminado)
        {
            ReiniciarJuego();
            return;
        }

        string respuesta = campoRespuesta.text.Trim().ToUpperInvariant();

        bool correcta = false;

        if (pruebaActual == 0)
        {
            correcta = respuesta == "NO TODO TERMINA AL DESPERTAR";
        }
        else if (pruebaActual == 1)
        {
            correcta = respuesta == "SOMBRA";
        }
        else if (pruebaActual == 2)
        {
            correcta = respuesta == "AMANECER";
        }

        if (correcta)
        {
            pruebaActual++;

            if (pruebaActual >= 3)
            {
                MostrarFinal();
            }
            else
            {
                textoMensaje.text = "Correcto. Has encontrado otra pista.";
                IniciarPrueba();
            }
        }
        else
        {
            textoMensaje.text =
                "Respuesta incorrecta. Piensa e intenta otra vez.";

            campoRespuesta.text = "";
        }
    }

    private void MostrarFinal()
    {
        juegoTerminado = true;

        titulo.text = "NOS VEMOS MANANA";

        textoPrueba.text =
            "HAS DESCUBIERTO LA VERDAD\n\n" +
            "Creiste que hoy seria diferente...\n\n" +
            "El reloj vuelve a marcar las 8:00.\n" +
            "El ciclo no ha terminado.\n\n" +
            "NOS VEMOS MANANA.";

        textoMensaje.text =
            "Has completado las tres pruebas.";

        textoProgreso.text = "FINAL DESCUBIERTO";

        temporizador.text = "TIEMPO: --";

        campoRespuesta.text = "";
        campoRespuesta.interactable = false;

        TMP_Text textoBoton =
            botonComprobar.GetComponentInChildren<TMP_Text>();

        if (textoBoton != null)
        {
            textoBoton.text = "JUGAR OTRA VEZ";
        }
    }

    private void ReiniciarJuego()
    {
        pruebaActual = 0;

        TMP_Text textoBoton =
            botonComprobar.GetComponentInChildren<TMP_Text>();

        if (textoBoton != null)
        {
            textoBoton.text = "COMPROBAR RESPUESTA";
        }

        IniciarPrueba();
    }
}
