using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 1f;

    private float lastAttackTime = 0f;
    private BoxCollider2D colision;
    private Animator animador;

    // Variables para sonido
    [SerializeField] private AudioSource audioSource;  // Referencia al AudioSource
    [SerializeField] private AudioClip attackSound;    // Clip de sonido para el ataque

    void Start()
    {
        // Encuentra al jugador en la escena
        animador = GetComponentInParent<Animator>();
        colision = GetComponent<BoxCollider2D>();
    }

    private void Attack(Collider2D other)
    {
        Debug.Log("¡Ataque realizado! Daño: " + damage);

        // Reproducir sonido de ataque
        if (audioSource != null && attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);  // Reproduce el sonido de ataque
        }

        // Cambia las animaciones
        animador.SetBool("corriendo", false);
        animador.SetBool("atacando", true);

        // Aplica el daño al jugador
        other.gameObject.GetComponent<Vida>().daño(damage);
        other.gameObject.GetComponent<Mov_Jugador>().tomarDaño();

        // Actualiza el tiempo del último ataque
        lastAttackTime = Time.time;
    }

    public void DontAttack()
    {
        animador.SetBool("atacando", false);
        animador.SetBool("corriendo", true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Time.time >= lastAttackTime + attackCooldown)
        {
            Debug.Log("Se detectó al jugador");
            Attack(other);
            lastAttackTime = Time.time;
        }
    }
}
