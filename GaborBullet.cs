using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaborBullet : MonoBehaviour
{
    Transform enemyScale;
    bool lookingRight;
    public int speed;
    void Start()
    {
        enemyScale = GameObject.Find("Gabor").transform;
        if (enemyScale.localScale.x < 0)
        {
            lookingRight = true;
        }
        else
        {
            lookingRight = false;
        }
        speed = 10;
    }

    
    void Update()
    {

        if (lookingRight == true)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(1f, transform.localScale.y);
            Destroy(gameObject, 1f);
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.localScale = new Vector2(-1f, transform.localScale.y);
            Destroy(gameObject, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }


}
