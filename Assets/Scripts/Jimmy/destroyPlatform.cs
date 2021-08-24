using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPlatform : MonoBehaviour
{    

    private void OnCollisionEnter(Collision other){
        if(other.collider.CompareTag("Player")){
            Destroy(this.gameObject);
        }
    }
}
