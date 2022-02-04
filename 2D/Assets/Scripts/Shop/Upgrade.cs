using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade
{
    private string Name;

    public static string[] names = { "UpgradeStaff", "UpgradeSword", "PurchaseHealthPotion" };
    public static string[] descriptions = { 
        "The Staff is a long range weapon, that deals small amount of damage.",
        "The Sword is a short range weapon, that deals a huge amount of damage in return of its short range.",
        "The Health Potion grants you 50 health upon using it. \nEach potion can be used only once." 
    };

    /*public enum UpgradeName
    {
        UpgradeStaff,
        UpgradeSword,
        PurchaseHealthPotion,
    }*/

    public Upgrade(string nName)
    {
        this.Name = nName;
        Debug.Log(this.Name);
    }
}
