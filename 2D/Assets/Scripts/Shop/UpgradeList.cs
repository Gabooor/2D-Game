using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeList
{
    public event EventHandler OnItemListChanged;
    public List<Upgrade> upgradeList;

    public UpgradeList()
    {
        upgradeList = new List<Upgrade>();
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        upgradeList.Add(upgrade);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Upgrade> GetUpgradeList()
    {
        return upgradeList;
    }
}
