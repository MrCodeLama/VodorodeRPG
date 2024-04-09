using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
   public static ShopManager instance;
   public int coins = 300;
   //public Upgrade[] upgrades;
   public Text coinText;
   public GameObject shopUI;

   private void Awake()
   {
      if (instance==null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(gameObject);
   }

   public void ToggleShop()
   {
      shopUI.SetActive(!shopUI.activeSelf);
   }
}
