using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int MAX_VIDA = 50;
    [SerializeField] private int vida = 50;

    // Update is called once per frame

    private void daño(int cantidad){ 
        if(vida !< 0) this.vida -= cantidad; 
    }

    private void curacion(int cantidad){ 
        this.vida += cantidad; 
        if(vida > MAX_VIDA) this.vida = MAX_VIDA;
    }

    private void morir(){
        if(vida < 0){
            Destroy(gameObject);
        }
    }

}
