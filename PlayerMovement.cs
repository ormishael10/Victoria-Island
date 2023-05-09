using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    float xDir;
    bool canJump;
    Animator animControl;
    public ParticleSystem PS;
    public AudioSource audio;
    public AudioClip jumpSound;

    float firePosition;
    float nextSlide = 0;
    float slidePerSec = 0.5f;

    public bool lookingRight;

    public GameObject bulletFire;
    float nextFire = 0;
    float firePerSec = 3f;

    void Start()
    { 
        
        speed = 5;
        animControl= GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        canJump= false;
        lookingRight = true;
    }

    
    void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CreatDust();
            xDir = -1;
            transform.localScale = new Vector2(-0.2f, transform.localScale.y);
            lookingRight = false;
            firePosition = -0.5f;
            
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            CreatDust();
            xDir = 1;
            transform.localScale = new Vector2(0.2f, transform.localScale.y);
            lookingRight = true;
            firePosition = 0.5f;
           
        }
        else
        {
            
            xDir = 0;
        }
        transform.position = new Vector2(transform.position.x + xDir * speed * Time.deltaTime, transform.position.y);

        if(Input.GetKeyDown(KeyCode.UpArrow) && canJump == true) 
        {
            rb.AddForce(new Vector2(0, 500));
            canJump = false;
            animControl.SetBool("isJumping", true);
            audio.PlayOneShot(jumpSound);
        }

        if(Time.time >= nextSlide)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if(lookingRight)
                {
                    rb.AddForce(new Vector2(300f, 0));
                    animControl.SetTrigger("Slide");
                }
                else
                {
                    rb.AddForce(new Vector2(-300f, 0));
                    animControl.SetTrigger("Slide");
                }
                nextSlide = Time.time + 1f / slidePerSec;
            }
        }
        
        if(Time.time >= nextFire)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Instantiate(bulletFire, new Vector2(transform.position.x + firePosition, transform.position.y), bulletFire.transform.rotation);
                nextFire = Time.time + 1f / firePerSec;
                animControl.SetBool("isShotting", true);
               
            }
           else
            {
                animControl.SetBool("isShotting", false);
            }

               
        }
        

        if (xDir != 0 && canJump)
        {

            animControl.SetBool("isRunning", true);
        }
        else
        {
            animControl.SetBool("isRunning", false);
        }

       


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
            print(canJump);
            animControl.SetBool("isJumping", false);
        }
    }
   
    void CreatDust()
    {
        PS.Play();
    }

}
