using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private List<TMP_Text> slotTexts;

    public void UpdateUI()
    {
        var items = inventory.GetItems();

        for (int i = 0; i < slotTexts.Count; i++)
        {
            if (i < items.Count)
            {
                slotTexts[i].text = items[i].itemName + " x" + items[i].count;
            }
            else
            {
                slotTexts[i].text = "Empty";
            }
        }
    }
}