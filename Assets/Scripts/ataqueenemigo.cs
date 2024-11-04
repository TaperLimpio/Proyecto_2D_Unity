using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 1f;

    private float lastAttackTime = 0f;
    private BoxCollider2D colision;
    private Animator animador;

    void Start()
    {
        // Encuentra al jugador en la escena
        animador = GetComponentInParent<Animator>();
        colision = GetComponent<BoxCollider2D>();
    }
    /*
    void Update()
    {
        if (player != null)
        {
            // Comprobar la distancia al jugador
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
            }
        }
    }
    */
    private void Attack(Collider2D other)
    {
        Debug.Log("¡Ataque realizado! Daño: " + damage);
        animador.SetBool("corriendo",false);
        animador.SetBool("atacando",true);
        // Actualiza el tiempo del último ataque 
        other.gameObject.GetComponent<Vida>().daño(damage);
        other.gameObject.GetComponent<Mov_Jugador>().tomarDaño();
        lastAttackTime = Time.time;
    }

    public void DontAttack(){
        animador.SetBool("atacando",false);
        animador.SetBool("corriendo",true);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && Time.time >= lastAttackTime + attackCooldown){
            Debug.Log("Se detecto al jugador");
            Attack(other);
            lastAttackTime = Time.time;
        }
    }

}
