using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeInvocacion : MonoBehaviour
{
    [SerializeField] private GameObject invocacion;
    [SerializeField] private GameObject[] InvoPosiciones;
    void Start()
    {
        InvokeRepeating("InvocarMinions",12f,12f);
    }

    private void InvocarMinions(){
        GetComponentInParent<Animator>().SetBool("invocando",true);
        GetComponentInParent<Animator>().SetBool("moviendo",true);
        foreach(GameObject pos in InvoPosiciones){
            Instantiate(invocacion,pos.transform.position,pos.transform.rotation);
        }
    }

}
