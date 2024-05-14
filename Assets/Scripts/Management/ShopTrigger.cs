using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    private ShopManager shopManager;

    private void Awake()
    {
        shopManager = GameObject.FindWithTag("ShopManager").GetComponent<ShopManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            Debug.Log("fdghj");
            shopManager.ToggleShop();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            Debug.Log("fdghj");
            shopManager.ToggleShop();
        }
    }
}
