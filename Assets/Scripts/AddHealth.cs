using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHealth : MonoBehaviour
{
    [SerializeField] PlayerRespawn playerRespawnScript;
    [SerializeField] private AudioSource collelctionSoundEffect;
    [SerializeField] private Image healthBar;

    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.CompareTag("Heart")){
            if(healthBar.fillAmount < 0.3){
                collelctionSoundEffect.Play();
                Destroy(coll.gameObject);
                healthBar.fillAmount = healthBar.fillAmount + 0.1f;
                playerRespawnScript.totalLives = playerRespawnScript.totalLives + 1;
            }
        }
    }
}
