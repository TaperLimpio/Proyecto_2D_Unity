using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeAtaque : MonoBehaviour
{

    public int damage = 10;

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Vida>().daño(damage);
            other.gameObject.GetComponent<Mov_Jugador>().tomarDaño();   
        }
    
    }
}
