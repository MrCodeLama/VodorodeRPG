using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
   private GameManager gameManager;
   public static ShopManager instance;
   public Upgrade[] upgrades;
   private bool toggle = false;
   public GameObject shopUI;
   public Transform shopContent;
   public GameObject itemPrefab;
   public PlayerController player;
   private EconomyManager economyManager;
   private PlayerHealth playerHealth;
   [SerializeField] private AudioSource buysound;
   private void Awake()
   {
      economyManager = GameObject.FindGameObjectWithTag("EconomyManager").GetComponent<EconomyManager>();
      gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
      playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
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
      if (economyManager.currentGold>=upgrade.cost)
      {
         buysound.Play();
         economyManager.currentGold -= upgrade.cost;
         upgrade.quantity++;
         upgrade.itemRef.transform.GetChild(0).GetComponent<Text>().text = upgrade.quantity.ToString();
         ApplyUpgrade(upgrade);
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
            playerHealth.addHP(upgrade.healthRestore);
            break;
         default:
            Debug.Log("no upgrade availible");
            break;
      }
   }
   public void ToggleShop()
   {
      Debug.Log("fdas");
      toggle = !toggle;
      shopUI.SetActive(toggle);
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
