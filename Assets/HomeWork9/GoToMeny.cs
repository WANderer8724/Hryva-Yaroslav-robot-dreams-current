using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class GoToMeny : MonoBehaviour
{
    [SerializeField] InputAction action;
    [SerializeField] InputAction Inventory;

    [SerializeField] GameObject layout;

    private bool isOpen = false;

    private void OnEnable()
    {
        action.Enable();
        action.performed += Back;

        Inventory.Enable();
        Inventory.performed += InventoryOpen;
    }

    private void OnDisable()
    {
        action.performed -= Back;
        action.Disable();

        Inventory.performed -= InventoryOpen;
        Inventory.Disable();
    }

    void Back(CallbackContext context)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    void InventoryOpen(CallbackContext context)
    {
        isOpen = !isOpen; 

        layout.SetActive(isOpen);

        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}