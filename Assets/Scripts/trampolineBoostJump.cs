using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineBoostJump : MonoBehaviour
{
    [SerializeField] private float bounceSpeed = 20f;
    [SerializeField] private AudioSource boostJmpSoundEffect;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.CompareTag("Player")){
            coll.gameObject.GetComponent<playerMovement>().jumpCount = coll.gameObject.GetComponent<playerMovement>().maxJumps;
            boostJmpSoundEffect.Play();
            anim.SetTrigger("trampolineAnimation");
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bounceSpeed, ForceMode2D.Impulse);
        }
    }
}
