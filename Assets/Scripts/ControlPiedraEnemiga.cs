using UnityEngine;

public class ControlPiedraEnemiga : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 posicionInicial;
    private Vector3 posicionDestino;
    private float tiempoTranscurrido = 0f;
    private bool gravedadActivada = false;

    public float tiempoEspera = 5f; // Tiempo en segundos antes de activar la gravedad
    public float tiempoRegreso = 2f; // Tiempo en segundos para el regreso progresivo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        posicionInicial = transform.position; // Guarda la posición inicial
        posicionDestino = posicionInicial;
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;

        if (!gravedadActivada && tiempoTranscurrido >= tiempoEspera)
        {
            rb.gravityScale = 1f; // Activa la gravedad
            gravedadActivada = true;
        }

        // Aquí puedes agregar el código de movimiento de tu piedra enemiga

        // Si ha pasado el tiempo y la gravedad está activada, inicia el regreso progresivo
        if (gravedadActivada && tiempoTranscurrido >= tiempoEspera + tiempoRegreso)
        {
            ResetearPosicionProgresivamente();
        }
    }

    void ResetearPosicionProgresivamente()
    {
        // Calcula la posición intermedia para el regreso progresivo
        float t = (tiempoTranscurrido - (tiempoEspera + tiempoRegreso)) / tiempoRegreso;
        t = Mathf.Clamp01(t); // Asegura que t esté en el rango [0, 1]
        Vector3 posicionIntermedia = Vector3.Lerp(transform.position, posicionDestino, t);

        // Aplica la posición intermedia
        transform.position = posicionIntermedia;

        // Si alcanza la posición de destino, desactiva la gravedad y reinicia el contador de tiempo
        if (t >= 1f)
        {
            rb.gravityScale = 0f;
            tiempoTranscurrido = 0f;
            gravedadActivada = false;
        }
    }
}