using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioSource checkpointSoundEffect;
    [SerializeField] private AudioSource gameEndSoundEffect;
    [SerializeField] private GameObject[] checkpoints;
    [SerializeField] private int nextCheckpointIndex = 0;
    private bool checkpointReached = false;
    public int totalLives = 2;
    private Animator anim;
    private Rigidbody2D rigidBody;
    [SerializeField] private GameOverScreen gameOver;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Respawn(){
        if(totalLives == 0){
            gameEndSoundEffect.Play();
            Invoke("GameOver", 1f);
        }
        else{   
            totalLives--;
            anim.ResetTrigger("death");
            anim.SetTrigger("respawn");
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
            transform.position = new Vector2(checkpoints[nextCheckpointIndex].transform.position.x, checkpoints[nextCheckpointIndex].transform.position.y);
        }
    }

    private void GameOver(){
        gameOver.Setup();
    }
    private void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.CompareTag("Checkpoint") && checkpointReached == false){
            checkpointReached = true;
            coll.GetComponent<Collider2D>().enabled = false;
            coll.GetComponent<Animator>().SetTrigger("checkpointReached");
            checkpointSoundEffect.Play();
            nextCheckpointIndex++;
            Invoke("addDelayCheckpoint", 0.1f);
        }
    }
    private void addDelayCheckpoint(){
        checkpointReached = false;
    }
}
