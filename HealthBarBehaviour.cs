using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Slider slider;
    public Color color;
    Vector3 Offset;// use this cuz not all monsters on same hight
    
    public void SetHealth(float health , float maxHealth)
    {
        slider.gameObject.SetActive(health < maxHealth); // we can see the health bar only if we damage the enemy
        slider.value = health;
        slider.maxValue= maxHealth;
    }

    void Update()
    {//  transforms the position from 3D world to 2D screen point
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
    }
}
