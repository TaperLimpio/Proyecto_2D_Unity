using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vida : MonoBehaviour
{
    [SerializeField] private Text vidaui;
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

    public void daño(int cantidad){ 
        Debug.Log("Se recibio daño");
        if(vida != 0) this.vida -= cantidad; 
    }

    public void curacion(int cantidad){ 
        this.vida += cantidad; 
        if(vida > MAX_VIDA) this.vida = MAX_VIDA;
    }

    public void actualizarUI(){
        this.vidaui.text = "HP: " + vida.ToString() + " | " + MAX_VIDA.ToString();
    }

    public void morir(){
        this.vida = 0;
        actualizarUI();
    }

}
