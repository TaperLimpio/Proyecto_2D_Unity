using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocion_mas_vida : MonoBehaviour
{
    [SerializeField] private int aumento;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Vida>().AumentarVida(aumento);
            Destroy(gameObject);
        }
    }

}
