using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    
    [SerializeField] private GameObject drop;
    private Transform dropposicion;

    void Start(){
        dropposicion = GetComponentInChildren<Transform>();
    }

    public void Dropear(){
        drop.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        drop.GetComponent<Rigidbody2D>().mass = 2;
        Instantiate(drop,dropposicion.position,dropposicion.rotation);
        Destroy(gameObject);
    }
}
