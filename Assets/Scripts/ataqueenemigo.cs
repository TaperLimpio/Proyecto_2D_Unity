using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 1f;

    private float lastAttackTime = 0f;
    private GameObject player;

    void Start()
    {
        // Encuentra al jugador en la escena
        player = GameObject.FindGameObjectWithTag("Player");
    }

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

    void Attack()
    {

        Debug.Log("¡Ataque realizado! Daño: " + damage);

        // Actualiza el tiempo del último ataque
        lastAttackTime = Time.time;


    }
}
