using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMowemant : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] float speed;

    [SerializeField] InputAction hoirzontalAxis;
    [SerializeField] InputAction verticalAxis;

    [SerializeField] private Vector2 input;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private Animator animator;
    private void OnEnable()
    {
        hoirzontalAxis.Enable();
        verticalAxis.Enable();
    }
    private void OnDisable()
    {
        hoirzontalAxis.Disable();
        verticalAxis.Disable();
    }
    private void Update()
    {
        input.x = hoirzontalAxis.ReadValue<float>();
        input.y = verticalAxis.ReadValue<float>();
        animator.SetFloat("SpeedX", input.x);
        animator.SetFloat("SpeedY", input.y);
        Vector3 moveDirection = transform.right * input.x + transform.forward * input.y;
        characterController.SimpleMove(moveDirection * speed);
    }

}
