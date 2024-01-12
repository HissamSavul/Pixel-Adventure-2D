using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class madeToCheckpoint : MonoBehaviour
{
    private AudioSource checkpointSoundEffect;
    private Animator anim;
    private bool checkpoint = false;
    private void Start()
    {
        checkpointSoundEffect = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player" && !checkpoint){
            anim.SetTrigger("checkpointReached");
            checkpointSoundEffect.Play();
            checkpoint = true;
        }
    }

}
