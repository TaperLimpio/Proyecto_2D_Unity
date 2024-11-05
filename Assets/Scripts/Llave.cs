using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    [SerializeField] private int keyid;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Inventario>().DesbloquearLlave(keyid);
            other.gameObject.GetComponent<Inventario>().obtenerLlaves();
            Destroy(gameObject);
        }
    }
}
