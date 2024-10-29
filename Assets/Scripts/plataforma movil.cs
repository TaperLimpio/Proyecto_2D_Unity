using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    [SerializeField] private GameObject[] puntos;
    [SerializeField] private float velocidad = 2f;
    private int puntoActual = 0;
   
    // Update is called once per frame
    void Update()
    {
       if (Vector2.Distance(puntos[puntoActual].transform.position, transform.position) < 0.1f) {
            puntoActual++;
            if (puntoActual > puntos.Length -1) {
                puntoActual = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, puntos[puntoActual].transform.position, velocidad * Time.deltaTime);    
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Player"){
            other.gameObject.transform.SetParent(null);
        }
    }
}

