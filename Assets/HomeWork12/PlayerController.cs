using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance => instance;

    [SerializeField] Collider collider;
    public Collider Collider => collider;

    [SerializeField] private Inventory inventory;

    public Inventory Inventory => inventory;
    private void Awake()
    {
        instance = this;
    }
    private void OnDestroy()
    {
        instance = null;
    }
}
