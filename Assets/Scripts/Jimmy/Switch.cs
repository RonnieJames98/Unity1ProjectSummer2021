using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject door;

    private void OnCollisionEnter(Collision other){
        if(other.collider.CompareTag("Player")){
            Destroy(door);
        }
    }

}
