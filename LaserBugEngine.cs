using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBugEngine : MonoBehaviour
{
    public float maxHealth = 200;
    float currentHP;
    public float takingDamageFromBullt;
    public GameObject enemyLaser;
    float timer;
    Rigidbody2D rb;
    Animator anim;
    Transform enemy;
    public ParticleSystem PS;
    public AudioSource audio;
    public AudioClip laserBugSound;
    public HealthBarBehaviour healthBar;
    
    void Start()
    {
        
        currentHP = maxHealth;
        takingDamageFromBullt = 50;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar.SetHealth(currentHP, maxHealth);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            
            timer = 0;
            Instantiate(enemyLaser, new Vector2(transform.position.x -1f, transform.position.y), enemyLaser.transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            currentHP -= takingDamageFromBullt;
            anim.SetTrigger("Hurt");
            PS.Play(true);
            audio.PlayOneShot(laserBugSound);
            healthBar.SetHealth(currentHP, maxHealth);

            if (currentHP <= 0)
            {
                anim.SetBool("isDead", true);
                
             
                Destroy(gameObject, 0.8f);
            }
        }

    }
}
