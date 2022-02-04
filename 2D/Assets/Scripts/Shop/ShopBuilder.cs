using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class ShopBuilder : MonoBehaviour
{
    public static UpgradeList upgradeList;
    [SerializeField] private Shop shop;

    // Start is called before the first frame update
    void Start()
    {
        upgradeList = new UpgradeList();
        shop.SetUpgradeList(upgradeList);
        for (int i = 0; i < Upgrade.names.Length; i++)
        {
            Upgrade upgrade = new Upgrade(Upgrade.names[i]);
            Debug.Log(upgrade);
            upgradeList.AddUpgrade(upgrade);
        }

    }
}
