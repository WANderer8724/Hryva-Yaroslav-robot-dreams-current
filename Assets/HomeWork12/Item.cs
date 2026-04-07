using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int amount ;

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerController.Instance.Collider)
        {
            Inventory inventory = PlayerController.Instance.Inventory;

            if (inventory != null)
            {
                inventory.AddItem(itemName, amount);
                Destroy(gameObject);
            }
        }
    }
}