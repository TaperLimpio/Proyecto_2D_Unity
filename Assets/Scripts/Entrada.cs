using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entrada : MonoBehaviour
{
    private int keydigit;

    void Start(){
        keydigit = GetComponentInParent<Puerta>().GetKeydigit();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && 
            other.gameObject.GetComponent<Inventario>().VerificarLLaves(keydigit)){
            GetComponentInParent<Puerta>().abrirPuerta();
            if(keydigit == 2){
                other.gameObject.GetComponent<Mov_Jugador>().peleandoconjefe = true;
            }
        }
    }

}
