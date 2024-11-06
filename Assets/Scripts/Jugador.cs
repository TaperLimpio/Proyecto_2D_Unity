using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mov_Jugador : MonoBehaviour
{
    [SerializeField]
    private float velocidad;
    [SerializeField]
    private float fuerzaSalto;
    private Vida vida;
    [SerializeField]
    private int limiteSaltos = 2;  // Límite de saltos (2 para doble salto)
    private int saltosRestantes;  // Contador de saltos disponibles
    private Rigidbody2D rb;
    private Animator animador;
    private SpriteRenderer RenderSprite;
    
    public bool peleandoconjefe = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        RenderSprite = GetComponent<SpriteRenderer>();
        vida = GetComponent<Vida>();
        saltosRestantes = limiteSaltos;  // Inicialmente puede saltar hasta el límite
    }

    // Update is called once per frame
    void Update()
    {
        // Captura controles
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * velocidad, rb.velocity.y);

        // Verifica si el jugador puede saltar (si tiene saltos restantes)
        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0)
        {
            var impulso = new Vector2(0, fuerzaSalto);
            rb.AddForce(impulso, ForceMode2D.Impulse);
            saltosRestantes--;  // Reduce el número de saltos disponibles
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animador.SetBool("Golpeando",true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<Inventario>().usarPoti();
        }

        // Gestiona animaciones
        calcularAnimacion();
    }

    public void NoAtacar(){
        animador.SetBool("Golpeando",false);
    }

    void calcularAnimacion()
    {
        var movimientoX = Input.GetAxis("Horizontal");
        if (movimientoX > 0)
        {
            animador.SetBool("Direccion", false);
            animador.SetBool("Caminando", true);
        }
        else if (movimientoX < 0)
        {
            animador.SetBool("Direccion", true);
            animador.SetBool("Caminando", true);
        }
        else if (movimientoX == 0)
        {
            animador.SetBool("Caminando", false);
        }

        // Verifica el estado de salto y caída
        if (rb.velocity.y > 1.1f)
        {
            animador.SetBool("Saltando", true);
        }
        else if (rb.velocity.y < -1.1f)
        {
            animador.SetBool("Cayendo", true);
            animador.SetBool("Saltando", false);
        }
        else if (rb.velocity.y == 0)
        {
            animador.SetBool("Saltando", false);
            animador.SetBool("Cayendo", false);
            saltosRestantes = limiteSaltos;  // Restablece los saltos al tocar el suelo
        }

    }

    public void tomarDaño(){
        if(vida.getVida() == 0){
            morir();
        }
    }

    public void morir(){
        animador.SetTrigger("Muerto");
        rb.bodyType = RigidbodyType2D.Static;
        if (GetComponent<Vida>()) vida.morir();
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Instakill")
        {
            morir();
        }
    }
}
