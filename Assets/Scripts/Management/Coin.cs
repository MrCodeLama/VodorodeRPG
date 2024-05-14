using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
     public static int totalCoins = 0;
     int value;
     private EconomyManager economyManager;
     private void Start()
     {
         economyManager = GameObject.FindGameObjectWithTag("EconomyManager").GetComponent<EconomyManager>();
         value = Random.Range(10, 40);
     }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            economyManager.currentGold+=value; 
                //Destroy(gameObject);

        }
    }
}