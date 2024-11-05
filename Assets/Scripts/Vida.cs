using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] private int MAX_VIDA = 50;
    [SerializeField] private int vida = 50;

    // Evento para notificar cambios en la vida
    public delegate void VidaChanged(int nuevaVida);
    public event VidaChanged OnVidaChanged;

    public int getVida()
    {
        return this.vida;
    }

    public void setVida(int can)
    {
        this.vida = can;
        OnVidaChanged?.Invoke(vida); // Notifica el cambio
    }

    public int getMaxVida()
    {
        return this.MAX_VIDA;
    }

    public void setMaxVida(int can)
    {
        this.MAX_VIDA = can;
    }

    public void daño(int cantidad)
    {
        if (vida > 0)
        {
            vida -= cantidad;
            if (vida < 0) vida = 0;
            Debug.Log("Se recibió daño. Vida restante: " + vida);
            OnVidaChanged?.Invoke(vida); // Notifica el cambio
        }
    }

    public void curacion(int cantidad)
    {
        vida += cantidad;
        if (vida > MAX_VIDA) vida = MAX_VIDA;
        OnVidaChanged?.Invoke(vida); // Notifica el cambio
    }


    public void morir()
    {
        this.vida = 0;
        Debug.Log("El jugador ha muerto.");
        OnVidaChanged?.Invoke(vida); // Notifica el cambio
    }

    public bool estaVivo()
    {
        return vida > 0;
    }
}
