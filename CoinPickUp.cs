using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip coinSound;
    public int value = 10; // how much the coin worth
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audio.PlayOneShot(coinSound);
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }
}
