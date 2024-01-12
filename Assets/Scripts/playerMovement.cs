using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spRenderer;
    private BoxCollider2D boxColl;
    private float directionX = 0f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpSpeed = 13f;
    [SerializeField] private PauseScreen pauseMenu;
    [SerializeField] private GameOverScreen gameOver;

    private enum movementState { idle, running, jumping, falling, doubleJumping };
    [SerializeField] private AudioSource jmpSoundEffect;
    public int maxJumps = 2;
    public int jumpCount;
    // Start is called before the first frame update
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
        boxColl = GetComponent<BoxCollider2D>();
        jumpCount = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gameOver.gameObject.activeSelf == false){
            pauseMenu.SetupPause();
        }
        if(isGrounded() && rigidBody.velocity.y <= 0){
            jumpCount = 0;
        }
        //for horizontal movement
        directionX = Input.GetAxisRaw("Horizontal"); 
        rigidBody.velocity = new Vector2(moveSpeed*directionX,rigidBody.velocity.y);
        //for vertical movement
        if(Input.GetButtonDown("Jump") && jumpCount < maxJumps){
            jumpCount++;
            jmpSoundEffect.Play();
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        updateAnimation();
    }
    private void updateAnimation(){

        movementState state;

        if(directionX > 0f){
            state = movementState.running;
            spRenderer.flipX = false;
        }
        else if(directionX < 0f){
            state = movementState.running;
            spRenderer.flipX = true;
        }
        else{
            state = movementState.idle;
        }

        if(rigidBody.velocity.y > .1f && jumpCount == 1){
            state = movementState.jumping;
        }
        else if(rigidBody.velocity.y > .1f && jumpCount == 2){
            state = movementState.doubleJumping;
        }
        else if(rigidBody.velocity.y < -.1f){
            state = movementState.falling;
        }

        animator.SetInteger("state", (int)state );
    }


    private bool isGrounded(){
        return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
