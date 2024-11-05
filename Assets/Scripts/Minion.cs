using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private int damage;
    public float attackCooldown = 1f;
    private float lastAttackTime = 0f;
    private Transform positionJugador;
    void Start()
    {
        positionJugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Invoke("muriendo",8f);
    }

    public void terminoInvocacion(){
        GetComponent<Animator>().SetBool("existiendo",true);
    }

    public void muriendo(){
        GetComponent<Animator>().SetTrigger("muerte");
    }

    public void muerto(){
        Destroy(gameObject);
    }

    void Update()
    {
        mover();  
    }
    private void mover(){
        transform.position = Vector2.MoveTowards(transform.position,positionJugador.position,velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Time.time >= lastAttackTime + attackCooldown){
            other.gameObject.GetComponent<Vida>().daño(damage);
            other.gameObject.GetComponent<Mov_Jugador>().tomarDaño();
            lastAttackTime = Time.time;
        }
    }

}
