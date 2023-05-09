using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GaborEngine : MonoBehaviour
{

    public float maxHealth = 1500;
    public float currentHP;
    public float speed;
    public bool isRight;
    
    Animator animator;
    Rigidbody2D gaborRB;
    public ParticleSystem PS;
    public AudioSource audio;
    public AudioClip hurt;
    public HealthBarBehaviour healthBar;
    public float takingDamageFromBullt;
    float timer;
    public GameObject gaborBullet;
   
    void Start()
    {
        currentHP = maxHealth; // set maxhealth to the current health
        healthBar.SetHealth(currentHP, maxHealth);
        speed = 5f;
        animator = GetComponent<Animator>();
        gaborRB = GetComponent<Rigidbody2D>();
        takingDamageFromBullt = 50;
    }

  
    void Update()
    {
        if(currentHP > 0)
        {
            if (isRight)
            {

                transform.Translate(-speed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(5, transform.localScale.y);
            }
            else
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(-5, transform.localScale.y);
            }
            
        }
        timer += Time.deltaTime;
        if(timer >= 1.5f)
        {
            float yPos = -3f;// set the first bullet
            timer = 0;
            int amountOfBullets = 1;
            while(amountOfBullets <= 3 && isRight)
            {
                Instantiate(gaborBullet, new Vector2(transform.position.x - 1f, transform.position.y + yPos), gaborBullet.transform.rotation);
                amountOfBullets++;
                yPos += 1f;
            }

            while (amountOfBullets <= 3 && isRight == false)
            {
                Instantiate(gaborBullet, new Vector2(transform.position.x + 1f, transform.position.y + yPos), gaborBullet.transform.rotation);
                amountOfBullets++;
                yPos += 1f;
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (isRight)
            {
                isRight = false;
            }
            else
            {
                isRight = true;
            }
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            currentHP -= takingDamageFromBullt;
            animator.SetTrigger("Hurt");
            PS.Play(true);
            audio.PlayOneShot(hurt);
            healthBar.SetHealth(currentHP, maxHealth);

            if (currentHP <= 0)
            {
                    
                animator.SetBool("isDead", true);
               
                Destroy(gameObject, 1);
            }
        }
    }
    
}
