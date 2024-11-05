using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] public Text coinText;
    [SerializeField] public Text llavesText;
    [SerializeField] private int canMonedas = 0;
    private bool[] llaves;
    
    void Start(){
        llaves = new bool[2];
        Debug.Log(llaves.Length);
        for (int i = 0; i < llaves.Length; i++) { llaves[i] = false; }
    }
    public void obteneMoneda(int val){
        this.canMonedas += val;
        coinText.text = "$: " + canMonedas.ToString();
    }

    public void obtenerLlaves(){
        var texto = "";
        foreach(bool llave in llaves){
            if(llave){
                texto += "|*|  ";
            }else{
                texto += "| |  ";
            }
        }
        llavesText.text = "Llaves: " + texto.ToString();
    }

    public void DesbloquearLlave(int id){
        llaves[id] = true;
    }

    public bool VerificarLLaves(int keycode){
        if(llaves[keycode]){
            return true;
        }else{
            return false;
        }
    }

}
