using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    [SerializeField] private List<InventoryItem> itemsList = new();

    Dictionary<string,InventoryItem> items = new();

    [SerializeField] int gold;

    [SerializeField] private InventoryUI inventoryUI;

    [SerializeField] Text goldText;
    public int Gold => gold;
    public List<InventoryItem> GetItems()
    {
        return itemsList;
    }
    public void AddItem(string name, int amount)
    {

        if (items.TryGetValue(name,out InventoryItem item))
        {
            item.count += amount;
        }
        else
        {
            var newitem = new InventoryItem(name, amount);
            items.Add(name, newitem);
        }
        SyncToList();
        inventoryUI.UpdateUI();

    }

    public void AddGold(int gold)
    {
        this.gold += gold;
        goldText.text = "Gold: "+ this.gold;
    }
    private void SyncToList()
    {
        itemsList.Clear();

        foreach (var pair in items)
        {
            itemsList.Add(pair.Value);
        }
    }
}
