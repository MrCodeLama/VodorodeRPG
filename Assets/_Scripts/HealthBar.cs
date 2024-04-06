using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public Slider slider;

    private void Start()
    {
        slider.maxValue = gameManager.maxHP;
    }

    private void Update()
    {
        slider.value = gameManager.currentHP;
    }
}
