using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEngine : MonoBehaviour
{
    Transform playerScale;
    bool lookingRight;
    public int bulletSpeed;
    void Start()
    {
        bulletSpeed = 10;
        playerScale = GameObject.Find("Player").transform;
        if(playerScale.localScale.x > 0)
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
        }
    }

  
    void Update()
    {
        
        if(lookingRight)
        {
            transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);
            Destroy(gameObject, 1);
        }
        else
        {
            transform.Translate(-bulletSpeed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-0.3f, transform.localScale.y);
            Destroy(gameObject, 1);
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
