using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    [SerializeField] private Text collectablesText;
    [SerializeField] private Image healthBar;
    [SerializeField] PlayerRespawn playerRespawnScript;
    [SerializeField] private AudioSource collelctionSoundEffect;
    [SerializeField] private AudioSource heartCollelctionSoundEffect;    
    private int collectablesCount = 0;
    private bool cherryDestroyed  = false;
    private bool bananaDestroyed  = false;

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Cherry") && cherryDestroyed == false){
            cherryDestroyed = true;
            coll.GetComponent<Collider2D>().enabled = false;
            collectablesText.text = "POINTS: " + ++collectablesCount;
            collelctionSoundEffect.Play();
            coll.gameObject.GetComponent<Animator>().SetTrigger("isCollected");
            Invoke("addDelayCherry", 0.1f);
        }
        else if (coll.gameObject.CompareTag("Banana")  && bananaDestroyed == false){
            bananaDestroyed = true;
            coll.GetComponent<Collider2D>().enabled = false;
            collelctionSoundEffect.Play();
            collectablesText.text = "POINTS: " + ++collectablesCount;
            coll.gameObject.GetComponent<Animator>().SetTrigger("isCollected");
            Invoke("addDelayBanana", 0.1f);
        }
        if (coll.gameObject.CompareTag("Heart")){
            if(healthBar.fillAmount < 0.3){
                heartCollelctionSoundEffect.Play();
                coll.gameObject.GetComponent<Animator>().SetTrigger("isCollected");
                healthBar.fillAmount = healthBar.fillAmount + 0.1f;
                playerRespawnScript.totalLives = playerRespawnScript.totalLives + 1;
            }
        }
    }

    private void addDelayCherry(){
        cherryDestroyed = false;
    }
    private void addDelayBanana(){
        bananaDestroyed = false;
    }
}
