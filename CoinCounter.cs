using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;// allow us to access from CoinPickUp

    public TMP_Text coinText;

    public int currentCoins = 0;

    void Awake()
    {
        instance= this;
    }
    void Start()
    {
        coinText.text = "Coins: " + currentCoins.ToString();
    }

    public void IncreaseCoins(int v)// taje the amount of coins we have and add the value we give to the coin
    {
        currentCoins += v;
        coinText.text = "Coins: " + currentCoins.ToString();
    }
}
