using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce = 250;
    public float speed = 5;

    bool jump = false;
    bool gameStarted = false;
    bool grounded = false;

    Rigidbody2D rigidbody2D;
    Animator animator;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            if(grounded && gameStarted){
                jump = true;
                grounded = false;
                animator.SetTrigger("Jump");
                audioSource.Play();
            }else{
                gameStarted = true;
                animator.SetTrigger("Start");
                Debug.Log("1");
            }
        } 

        animator.SetBool("Grounded",grounded);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        grounded = true;
    }

    private void FixedUpdate() {
        if(gameStarted){
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
        if(jump){
            rigidbody2D.AddForce(new Vector2(0f,jumpForce));
            jump = false;
        }
    }
}
