using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    [SerializeField] private int keydigit = 2;
    private Transform[] listaEntradas;

    public int GetKeydigit(){
        return keydigit;
    }

    void Start(){
        listaEntradas = GetComponentsInChildren<Transform>();
        Debug.Log(listaEntradas);
    }

    public void abrirPuerta(){
        foreach( Transform comp in listaEntradas)
        {
            comp.GetComponent<BoxCollider2D>().enabled = false;
        }
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
