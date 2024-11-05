using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefemovimiento : MonoBehaviour
{

    [SerializeField] private GameObject[] puntos;
    [SerializeField] private float velocidad = 2f;
    private int puntoActual = 0;
    private Vida vida;

    void Start(){
        GetComponent<Animator>().SetBool("moviendo",true);
        vida = GetComponent<Vida>();
    }

    public void Morir(){
        Destroy(gameObject);
    }

    public void tomarDañoEnemigo(){
        if(vida.getVida() == 0){
            GetComponent<JefeAnimacion>().Muerto();
        }
    }

    void Update()
    {
        if (Vector2.Distance(puntos[puntoActual].transform.position, transform.position) < 0.1f) {
            puntoActual++;
            Debug.Log(puntoActual);
            if (puntoActual == 2 || puntoActual == 4){
                GetComponent<Transform>().localScale = new Vector3(-1,1,1);
            }else{
                GetComponent<Transform>().localScale = new Vector3(1,1,1);
            }
            if (puntoActual > puntos.Length -1) {
                puntoActual = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, puntos[puntoActual].transform.position, velocidad * Time.deltaTime);
    }
}
