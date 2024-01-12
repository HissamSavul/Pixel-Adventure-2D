using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll) {
         if(coll.gameObject.name == "Player"){
            coll.gameObject.transform.SetParent(transform);
        }       
    }

    private void OnTriggerExit2D(Collider2D coll) {
        if(coll.gameObject.name == "Player"){
            coll.gameObject.transform.SetParent(null);
        }        
    }
}
