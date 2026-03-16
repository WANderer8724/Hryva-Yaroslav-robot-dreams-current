using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class GoToMeny : MonoBehaviour
{
    [SerializeField] InputAction action;
    private void OnEnable()
    {
        action.Enable();
        action.performed += Back;
    }
    private void OnDisable()
    {
        action.performed -= Back;
        action.Disable();
    }
    void Back(CallbackContext context)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
