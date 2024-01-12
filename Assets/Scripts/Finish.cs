using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSoundEffect;
    private bool levelCompleted = false;
    private void Start()
    {
        finishSoundEffect = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.name == "Player" && !levelCompleted){
            finishSoundEffect.Play();
            levelCompleted = true;
            Invoke("levelCompletion", 2f);
        }
    }

    private void levelCompletion(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

