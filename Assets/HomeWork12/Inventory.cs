using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    Dictionary<string,InventoryItem> items = new();

    [SerializeField] int gold;

    public int Gold => gold;

    public void AddItem(string name, int amount)
    {

        if (!items.TryGetValue(name,out InventoryItem item))
        {
            item.count += amount;
        }
        else
        {
            var newitem = new InventoryItem(name, amount);
            items.Add(name, newitem);
        }
    }

    public void AddGold(int gold)
    {
        this.gold += gold;
    }
}
