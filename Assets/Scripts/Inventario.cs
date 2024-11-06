using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    [SerializeField] public Text coinText;
    [SerializeField] public Text llavesText;
    [SerializeField] public Text potisText;
    [SerializeField] private int canMonedas = 0;
    [SerializeField] private int canPotis = 0;
    private Vida vida;
    private bool[] llaves;

    
    void Start(){
        vida = GetComponent<Vida>();
        llaves = new bool[3];
        Debug.Log(llaves.Length);
        for (int i = 0; i < llaves.Length; i++) { llaves[i] = false; }
    }
    public void obteneMoneda(int val){
        this.canMonedas += val;
        coinText.text = "$: " + canMonedas.ToString();
    }

    public void obtenerPociones(int can){
        canPotis += can;
        potisText.text = "Pociones: " + canPotis.ToString();
    }

    public void usarPoti(){
        if(canPotis > 0 && vida.getVida() < vida.getMaxVida()){
            Debug.Log("Se uso poti");
            GetComponent<Vida>().curacion();
            canPotis -= 1;
            potisText.text = "Pociones: " + canPotis.ToString();
        }
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
        return llaves[keycode];
    }

}
