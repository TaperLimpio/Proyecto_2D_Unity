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
        Instantiate(drop,dropposicion.position,dropposicion.rotation);
        Destroy(gameObject);
    }
}
