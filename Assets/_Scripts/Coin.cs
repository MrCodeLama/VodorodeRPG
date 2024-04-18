using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
     public static int totalCoins = 0;
     int value;

     private void Start()
     {
         value = Random.Range(10, 40);
     }

     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShopManager.instance.coins+=value; 
                //Destroy(gameObject);

        }
    }
}