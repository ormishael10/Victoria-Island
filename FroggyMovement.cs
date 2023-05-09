using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FroggyMovement : MonoBehaviour
{
    
    public AudioSource audio;
    public AudioClip froggyHurt;
    Animator animator;
    public ParticleSystem froggyPS;
    public HealthBarBehaviour healthBar;
    public float maxHealth = 120;
    float currentHP;
    Rigidbody2D froggyRB;
    float froggyX;
    bool isRight;
    public float takingDamageFromBullt;
    public GameObject frogg;
    // Start is called before the first frame update
    void Start()
    {
        takingDamageFromBullt = 40;
        animator = GetComponent<Animator>();
        currentHP = maxHealth;
        froggyX = 1f;
        froggyRB= GetComponent<Rigidbody2D>();
        healthBar.SetHealth(currentHP, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP > 0)
        {
            if(isRight)
            {
                transform.Translate(froggyX * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(-0.5f, transform.localScale.y);
            }
            else
            {
                transform.Translate(-froggyX * Time.deltaTime, 0, 0);
                transform.localScale = new Vector2(0.5f, transform.localScale.y);
            }
        }
    }



    public void TakeDamage(float damage)
    {
        currentHP -= damage;

        animator.SetTrigger("Hurt");
       

        if (currentHP <= 0)
        {

            animator.SetBool("isDead", true);
            frogg.SetActive(false);
           /* Destroy(gameObject, 1);*/
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

        if(collision.gameObject.tag == "Bullet")
        {
            froggyPS.Play(true);
            Destroy(collision.gameObject);
            currentHP -= takingDamageFromBullt;
            animator.SetTrigger("Hurt");
            audio.PlayOneShot(froggyHurt);
            healthBar.SetHealth(currentHP, maxHealth);
            if (currentHP <= 0)
            {
                
                animator.SetBool("isDead", true);

                Destroy(gameObject, 1);
            }
        }
    }
}
