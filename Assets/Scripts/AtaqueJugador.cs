using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    [SerializeField] public int daño = 3;

    public void NoAttack(){
        GetComponentInParent<Animator>().SetBool("Golpeando",false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemigo"){
            other.gameObject.GetComponent<Animator>().SetBool("Dañado",true);
            other.gameObject.GetComponent<Vida>().daño(daño);
            other.gameObject.GetComponent<EnemyMovement2D>().tomarDañoEnemigo();
        }
        if(other.gameObject.tag == "Jefe"){
            other.gameObject.GetComponent<Animator>().SetBool("dañado",true);
            other.gameObject.GetComponent<Vida>().daño(daño);
            other.gameObject.GetComponent<Jefemovimiento>().tomarDañoEnemigo();
        }

        if(other.gameObject.tag == "Destructible"){
            other.gameObject.GetComponent<Destructible>().Dropear();
        }
    }

}
