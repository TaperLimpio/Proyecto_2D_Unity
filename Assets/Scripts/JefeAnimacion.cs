using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeAnimacion : MonoBehaviour
{
    private Animator animador;
    void Start()
    {
        animador = GetComponentInParent<Animator>();
    }

    public void NoAtacar(){
        animador.SetBool("atacando",false);
        animador.SetBool("moviendo",true);
    }

    public void NoInvocar(){
        animador.SetBool("invocando",false);
        animador.SetBool("moviendo",true);
    }

    public void NoDañado(){
        animador.SetBool("dañado",false);
        animador.SetBool("moviendo",true);
    }

    public void Muerto(){
        animador.SetTrigger("muerto");
    }

}
