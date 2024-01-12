using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerLife : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator anim;
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Trap")){
            Die();
        }
    }

    private void Die(){
        deathSoundEffect.Play();
        rigidBody.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death"); 
    }

    private void HealthBarDepletion(){
        healthBar.fillAmount = healthBar.fillAmount - 0.1f;   
    }
}
