using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldItem : MonoBehaviour
{
    [SerializeField] int GoldCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other == PlayerController.Instance.Collider)
        {
            Inventory inventory = PlayerController.Instance.Inventory;

            if (inventory != null)
            {
                inventory.AddGold(GoldCount);
                Destroy(gameObject);
            }
        }
    }
}
