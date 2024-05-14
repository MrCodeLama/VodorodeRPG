using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public Slider slider;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        slider.maxValue = playerHealth.maxHealth;
        
    }

    private void Update()
    {
        slider.value = playerHealth.currentHealth;
    }
}
