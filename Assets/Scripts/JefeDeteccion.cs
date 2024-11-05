using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeDeteccion : MonoBehaviour
{
    private Animator animador;
    public float attackCooldown = 1f;
    private float lastAttackTime = 0f;
    void Start(){
        animador = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" && Time.time >= lastAttackTime + attackCooldown){
            Debug.Log("Se detecto al jugador");
            animador.SetBool("moviendo",false);
            animador.SetBool("atacando",true);
            lastAttackTime = Time.time;
        }
    }
}
