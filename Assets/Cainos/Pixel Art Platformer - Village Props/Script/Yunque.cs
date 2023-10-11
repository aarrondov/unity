using System.Collections;
using UnityEngine;

public class YunqueScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool gravityEnabled = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f; // Desactiva la gravedad al principio
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EnableGravityAfterDelay(2f)); // Activa la gravedad después de 2 segundos
        }
    }

    IEnumerator EnableGravityAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb2d.gravityScale = 1f; // Activa la gravedad
    }
}
