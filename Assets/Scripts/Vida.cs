using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int MAX_VIDA = 50;
    [SerializeField] private int vida = 50;

    public int getVida(){
        return this.vida;
    }

    public void setVida(int can){
        this.vida = can;
    }

    public int getMaxVida(){
        return this.MAX_VIDA;
    }

    public void setMaxVida(int can){
        this.MAX_VIDA = can;
    }

    private void daño(int cantidad){ 
        if(vida !< 0) this.vida -= cantidad; 
    }

    private void curacion(int cantidad){ 
        this.vida += cantidad; 
        if(vida > MAX_VIDA) this.vida = MAX_VIDA;
    }

}
