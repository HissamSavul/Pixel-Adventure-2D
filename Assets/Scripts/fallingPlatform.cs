using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.CompareTag("Player")){
            anim.SetTrigger("fall");
            Invoke("removePlatform", 0.6f);
        }
    }

    private void removePlatform(){
        gameObject.SetActive(false);
        Invoke("reappearPlatform", 1f);
    }
    private void reappearPlatform(){
        anim.SetTrigger("reappear");
        gameObject.SetActive(true);
    }
}
