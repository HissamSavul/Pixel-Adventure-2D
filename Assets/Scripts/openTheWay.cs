using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTheWay : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private GameObject[] blocks;
    [SerializeField] private AudioSource boxDestructionSoundEffect;
    private bool audiOnImpactOnce = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.CompareTag("Player") && audiOnImpactOnce){
            anim.SetTrigger("openPlatform");
            boxCollider.offset = new Vector2(boxCollider.offset.x, -0.7091103f);
            for (int i = 0; i < blocks.Length; i++){
                boxDestructionSoundEffect.Play();
                blocks[i].GetComponent<Animator>().SetTrigger("destroy");
            }
            audiOnImpactOnce = false;
        }
    }
}
