using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //ADDING ITEMS
    private Inventory shopInventory;

    //STAFF
    private Text StaffLevelText;
    private Text StaffDamageText;
    private Text StaffFireRateText;
    private Text StaffPriceText;

    //SWORD
    private Text SwordLevelText;
    private Text SwordDamageText;
    private Text SwordFireRateText;
    private Text SwordPriceText;
    private bool isSwordUnlocked;
    private Text SwordButtonText;
    private int swordUnlockPrice;

    //HEALTH POTION
    private Text PotionHealingText;
    private Text PotionPriceText;

    // Start is called before the first frame update
    void Start()
    {
        swordUnlockPrice = 15;
        for(int level = 0; level < 150; level++)
        {
            //Debug.Log(Mathf.Round(0.02f * (Mathf.Pow(level + 1, 3)) + 0.4f * (Mathf.Pow(level + 1, 2)) + level + 1));
        }

        shopInventory = new Inventory();
        shopInventory.AddItem(new Item { itemType = Item.ItemType.Staff });
        shopInventory.AddItem(new Item { itemType = Item.ItemType.Sword });
        shopInventory.AddItem(new Item { itemType = Item.ItemType.HealthPotion });

        StaffLevelText = GameObject.Find("StaffLevelText").GetComponent<Text>();
        StaffLevelText.text = "Level: " + Player.staffLevel.ToString();
        StaffDamageText = GameObject.Find("StaffDamageText").GetComponent<Text>();
        StaffDamageText.text = "Damage: " + shopInventory.itemList[0].GetDamage(Player.staffLevel).ToString();
        StaffFireRateText = GameObject.Find("StaffFireRateText").GetComponent<Text>();
        StaffFireRateText.text = "Fire Rate: " + (1 / shopInventory.itemList[0].GetFireRate()).ToString("F2") + " / s";
        StaffPriceText = GameObject.Find("StaffPriceText").GetComponent<Text>();
        StaffPriceText.text = "Price: " + shopInventory.itemList[0].GetPrice(Player.staffLevel).ToString();

        SwordLevelText = GameObject.Find("SwordLevelText").GetComponent<Text>();
        SwordDamageText = GameObject.Find("SwordDamageText").GetComponent<Text>();
        SwordDamageText.text = "Damage: " + shopInventory.itemList[1].GetDamage(1).ToString();
        SwordFireRateText = GameObject.Find("SwordFireRateText").GetComponent<Text>();
        SwordFireRateText.text = "Fire Rate: " + (1 / shopInventory.itemList[1].GetFireRate()).ToString("F2") + " / s";
        SwordPriceText = GameObject.Find("SwordPriceText").GetComponent<Text>();
        SwordPriceText.text = "Price: " + swordUnlockPrice.ToString();
        SwordButtonText = GameObject.Find("SwordButtonText").GetComponent<Text>();

        PotionHealingText = GameObject.Find("PotionHealingText").GetComponent<Text>();
        PotionHealingText.text = "Healing: " + shopInventory.itemList[2].GetHealing().ToString();
        PotionPriceText = GameObject.Find("PotionPriceText").GetComponent<Text>();
        PotionPriceText.text = "Price: " + shopInventory.itemList[2].GetPrice(1).ToString();
    }

    public void UpgradeStaff()
    {
        if(Player.money >= shopInventory.itemList[0].GetPrice(Player.staffLevel))
        {
            Player.staffLevel++;
            StaffPriceText.text = "Price: " + shopInventory.itemList[0].GetPrice(Player.staffLevel).ToString();
            StaffDamageText.text = "Damage: " + shopInventory.itemList[0].GetDamage(Player.staffLevel).ToString();
            StaffLevelText.text = "Level: " + Player.staffLevel.ToString();
            Player.money -= shopInventory.itemList[0].GetPrice(Player.staffLevel-1);
            Player.moneyText.text = Player.money.ToString();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }


    public void UpgradeSword()
    {
        if (isSwordUnlocked)
        {
            if (Player.money >= shopInventory.itemList[1].GetPrice(Player.swordLevel))
            {
                Player.swordLevel++;
                SwordPriceText.text = "Price: " + shopInventory.itemList[1].GetPrice(Player.swordLevel).ToString();
                SwordDamageText.text = "Damage: " + shopInventory.itemList[1].GetDamage(Player.swordLevel).ToString();
                SwordLevelText.text = "Level: " + Player.swordLevel.ToString();
                Player.money -= shopInventory.itemList[1].GetPrice(Player.swordLevel - 1);
                Player.moneyText.text = Player.money.ToString();
            }
        }
        else
        {
            if(Player.money >= swordUnlockPrice)
            {
                Player.inventory.AddItem(new Item { itemType = Item.ItemType.Sword });
                Player.swordLevel++;
                isSwordUnlocked = true;
                SwordButtonText.text = "UPGRADE";
                SwordPriceText.text = "Price: " + shopInventory.itemList[1].GetPrice(Player.swordLevel).ToString();
                SwordDamageText.text = "Damage: " + shopInventory.itemList[1].GetDamage(Player.swordLevel).ToString();
                SwordLevelText.text = "Level: " + Player.swordLevel.ToString();
                Player.money -= swordUnlockPrice;
                Player.moneyText.text = Player.money.ToString();
                //Player.equippedItem = Player.inventory.itemList[Player.selectedSlotValue];
            }
        }
    }
}
