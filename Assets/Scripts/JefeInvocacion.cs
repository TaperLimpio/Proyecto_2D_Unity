using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeInvocacion : MonoBehaviour
{
    [SerializeField] private GameObject invocacion;
    [SerializeField] private GameObject[] InvoPosiciones;
    void Start()
    {
        Invoke("InvocarMinions",15f);
    }

    private void InvocarMinions(){
        foreach(GameObject pos in InvoPosiciones){
            Instantiate(invocacion,pos.transform.position,pos.transform.rotation);
        }
    }

}
