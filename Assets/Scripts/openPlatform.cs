using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPlatform : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxCollider;
    [SerializeField] private AudioSource soundEffect;
    [SerializeField] private GameObject waypoint;
    [SerializeField] private float moveDistance = 30.0f;
    [SerializeField] private bool xMove = true;
    private bool audiOnImpactOnce = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        if(coll.gameObject.CompareTag("Player") && audiOnImpactOnce){
            audiOnImpactOnce = false;
            soundEffect.Play();
            anim.SetTrigger("openPlatform");
            boxCollider.offset = new Vector2(boxCollider.offset.x, -0.7091103f);
            if(xMove == true)
                waypoint.transform.position = new Vector2(waypoint.transform.position.x + moveDistance, waypoint.transform.position.y);
            else 
                waypoint.transform.position = new Vector2(waypoint.transform.position.x, waypoint.transform.position.y - moveDistance);              
        }
    }
}
