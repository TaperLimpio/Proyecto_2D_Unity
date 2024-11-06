using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    [SerializeField] public int daño = 3;
    [SerializeField] private AudioSource audioSource;  // Referencia al AudioSource
    [SerializeField] private AudioClip sonidoAtaque;   // Clip de sonido para el ataque

    // Desactivar animación de ataque
    public void NoAttack()
    {
        GetComponentInParent<Animator>().SetBool("Golpeando", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Reproducir sonido del ataque cuando se detecta una colisión con un enemigo
        if (audioSource != null && sonidoAtaque != null)
        {
            audioSource.PlayOneShot(sonidoAtaque);  // Reproduce el sonido del ataque
        }

        // Colisión con enemigos
        if (other.gameObject.tag == "Enemigo")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Dañado", true);
            other.gameObject.GetComponent<Vida>().daño(daño);
            other.gameObject.GetComponent<EnemyMovement2D>().tomarDañoEnemigo();
        }

        // Colisión con jefe
        if (other.gameObject.tag == "Jefe")
        {
            other.gameObject.GetComponent<Animator>().SetBool("dañado", true);
            other.gameObject.GetComponent<Vida>().daño(daño);
            other.gameObject.GetComponent<Jefemovimiento>().tomarDañoEnemigo();
        }

        // Colisión con objetos destructibles
        if (other.gameObject.tag == "Destructible")
        {
            other.gameObject.GetComponent<Destructible>().Dropear();
        }
    }
}
