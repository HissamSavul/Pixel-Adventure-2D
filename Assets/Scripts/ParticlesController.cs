using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] ParticleSystem MovemenParticle;
    [SerializeField] ParticleSystem fallParticle;

    [Range(0,10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,0.2f)]
    [SerializeField] float dustFormationPeriod;
    [SerializeField] Rigidbody2D playerRb;

    float counter;
    bool isOnGround;

    private void Update() {
        counter += Time.deltaTime;

        if(isOnGround && Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity){
            if(counter > dustFormationPeriod){
                MovemenParticle.Play();
                counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.CompareTag("Ground")){
            fallParticle.Play();
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll) {
        if(coll.CompareTag("Ground")){
            isOnGround = false;
        }
    }
}
