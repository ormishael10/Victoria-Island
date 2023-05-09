using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEngine : MonoBehaviour
{
    Transform enemyScale;
    public float randomSpeedX = 10f;
    bool shotRight;

    void Start()
    {


        enemyScale = GameObject.Find("Laser Bug").transform;
        if (enemyScale.localScale.x < 0)
        {
            shotRight = true;
        }
        else
        {
            shotRight = false;
        }
        shotRight = false;
        Destroy(gameObject, 1.5f);
    }


    void Update()
    {
        if (shotRight == false)
        {
            transform.Translate(-10f * Time.deltaTime, 0, 0);
            Destroy(gameObject, 1.5f);
        }
        else
        {
            transform.Translate(10 * Time.deltaTime, 0, 0);
            Destroy(gameObject, 1.5f);
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
