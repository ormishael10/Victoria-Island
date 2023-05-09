using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 300;
    public HealthBar healthBar;
    public int amountOfHeal = 60;



    public AudioSource audio;
    public AudioClip potionSound;
    Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    
    void Update()
    {
        
        if(currentHealth <= 0)
        {
            anim.SetBool("isDead", true);
            SceneManager.LoadScene("TryAgain");

        }

       

    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "LaserBug" || collision.gameObject.tag == "Gabor")
        {
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            anim.SetTrigger("Hurt");
            rb.AddForce(new Vector2(-200 , 0));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            
            Destroy(collision.gameObject);
            currentHealth -= 20;
            healthBar.SetHealth(currentHealth);
            anim.SetTrigger("Hurt");
            
        }
        
        if(collision.gameObject.tag == "GaborBullet")
        {
            
            Destroy(collision.gameObject);
            currentHealth -= 55;
            healthBar.SetHealth(currentHealth);
            anim.SetTrigger("Hurt");
            
        }

        if(collision.gameObject.tag == "HP")
        {
            
            currentHealth += amountOfHeal;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
            audio.PlayOneShot(potionSound);
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
                healthBar.SetHealth(currentHealth);
                Destroy(collision.gameObject);
            }
        }
    }

   
}
