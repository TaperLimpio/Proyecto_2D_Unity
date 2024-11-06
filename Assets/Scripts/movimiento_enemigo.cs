using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyMovement2D : MonoBehaviour
{
    public float moveDistance = 2f; // Distancia total a mover
    public float moveSpeed = 2f; // Velocidad de movimiento

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private Animator animador;
    private SpriteRenderer sprite;
    private Vida vida;
    void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial
        targetPosition = startPosition + new Vector2(moveDistance, 0); // Calcula la posición objetivo a la derecha
        animador = GetComponent<Animator>(); // Obtiene el componente animador
        animador.SetBool("corriendo",true);
        vida = GetComponent<Vida>(); 
        sprite = GetComponent<SpriteRenderer>(); // Obtiene el componente spriterenderer
    }

    public void Morir(){
        Destroy(gameObject);
    }

    public void nodañado(){
        animador.SetBool("Dañado",false);
        animador.SetBool("corriendo",true);
    }

    public void tomarDañoEnemigo(){
        animador.SetBool("corriendo",false);
        if(vida.getVida() == 0){
            animador.SetTrigger("Muerto");
        }
    }
    void Update()
    {
        if(vida.getVida() != 0){
            // Mueve el enemigo hacia la posición objetivo
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Comprobar si ha alcanzado la posición objetivo
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                
                // Cambia la dirección
                if (targetPosition == startPosition + new Vector2(moveDistance, 0))
                {
                    targetPosition = startPosition - new Vector2(moveDistance, 0); // Cambia a la izquierda
                    GetComponent<Transform>().localScale = new Vector3(-1,1,1);
                }
                else
                {
                    targetPosition = startPosition + new Vector2(moveDistance, 0); // Cambia a la derecha
                    sprite.flipX = false;
                    GetComponent<Transform>().localScale = new Vector3(1,1,1);
                }
            }
        }

    }
}
