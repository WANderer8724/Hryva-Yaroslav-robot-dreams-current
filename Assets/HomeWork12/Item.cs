using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName;
    public int count;

    public PickupItem(string name, int amount)
    {
        name = itemName;
        amount = count;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerController.Instance.Collider)
        {
            Inventory inventory = PlayerController.Instance.Inventory;

            if (inventory != null)
            {
                inventory.AddItem(itemName, count);
                Destroy(gameObject);
            }
        }
    }
}