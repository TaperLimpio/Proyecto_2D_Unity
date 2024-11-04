using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    [SerializeField] public int daño = 3;

    public void NoAttack(){
        GetComponentInParent<Animator>().SetBool("atacando",false);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Enemigo"){
            other.gameObject.GetComponent<Vida>().daño(daño);
        }
    }

}
