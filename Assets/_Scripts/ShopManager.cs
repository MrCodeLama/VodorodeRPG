using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
   public static ShopManager instance;
   public int coins = 300;
   public Upgrade[] upgrades;
   
   public Text coinText;
   public GameObject shopUI;
   public Transform shopContent;
   public GameObject itemPrefab;
   //public PlayerMovement player;
   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
      DontDestroyOnLoad(gameObject);
   }

   public void Start()
   {
      foreach (Upgrade upgrade in upgrades)
      {
         GameObject item = Instantiate(itemPrefab, shopContent);

         upgrade.itemRef = item;

         foreach (Transform child in item.transform)
         {
            if (child.gameObject.name == "Quantity")
            {
               child.gameObject.GetComponent<Text>().text = upgrade.quantity.ToString();
            }
            else if (child.gameObject.name == "Cost")
            {
               child.gameObject.GetComponent<Text>().text = "Price: " + upgrade.cost.ToString();
            }
            else if (child.gameObject.name == "Title")
            {
               child.gameObject.GetComponent<Text>().text = upgrade.name;
            }
            else if (child.gameObject.name == "Image")
            {
               child.gameObject.GetComponent<Image>().sprite = upgrade.image;
            }
         }
      }
   }

   public void ToggleShop()
   {
      shopUI.SetActive(!shopUI.activeSelf);
   }

   public void Update()
   {
      coinText.text = "Coins: " + coins.ToString();
   }
}

[System.Serializable]
public class Upgrade
{
   public string name;
   public int cost;
   public Sprite image;
   [HideInInspector] public int quantity;
   [HideInInspector] public GameObject itemRef;
}
