using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
   private GameManager gameManager;
   public static ShopManager instance;
   public int coins = 300;
   public Upgrade[] upgrades;
   
   public Text coinText;
   public GameObject shopUI;
   public Transform shopContent;
   public GameObject itemPrefab;
   public PlayerController player;
   private void Awake()
   {
      shopUI = GameObject.FindWithTag("shopUI");
      gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
            else if (child.gameObject.name == "Name")
            {
               child.gameObject.GetComponent<Text>().text = upgrade.name;
            }
            else if (child.gameObject.name == "Image")
            {
               child.gameObject.GetComponent<Image>().sprite = upgrade.image;
            }
         }
         item.GetComponent<Button>().onClick.AddListener(() => { BuyUpgrade(upgrade);});
      }
   }

   public void BuyUpgrade(Upgrade upgrade)
   {
      if (coins>=upgrade.cost)
      {
         coins -= upgrade.cost;
         upgrade.quantity++;
         upgrade.itemRef.transform.GetChild(0).GetComponent<Text>().text = upgrade.quantity.ToString();
         ApplyUpgrade(upgrade);
         coinText.text = "Coins: " + coins.ToString(); 
      }
   }

   public void ApplyUpgrade(Upgrade upgrade)
   {
      switch (upgrade.name)
      {
         case "Speed":
            gameManager.moveSpeed += 2f;
            break;
         case "Health":
            //gameManager.addHP(upgrade.healthRestore);
            break;
         default:
            Debug.Log("no upgrade availible");
            break;
      }
   }
   public void ToggleShop()
   {
      shopUI.SetActive(!shopUI.activeSelf);
   }

   public void OnGUI()
   {
      coinText.text = "Coins: " + coins.ToString();
   }
}

[System.Serializable]
public class Upgrade
{
   public int healthRestore;
   public string name;
   public int cost;
   public Sprite image;
   [HideInInspector] public int quantity;
   [HideInInspector] public GameObject itemRef;
}
