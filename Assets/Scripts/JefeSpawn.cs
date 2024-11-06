using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            boss.SetActive(true);
            Destroy(gameObject);
        }
    }
}
