using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GunAimer : MonoBehaviour
{
    [SerializeField] private Transform CameraTrnsform;
    [SerializeField] GameObject weapon;

    [SerializeField] InputAction Shoot;

    [SerializeField] float damage;

    bool hit;
    public RaycastHit hitInfo;
    private void OnEnable()
    {
        Shoot.Enable();
        Shoot.performed += OnShoot;
    }
    private void OnDisable()
    {
        Shoot.performed -= OnShoot;
        Shoot.Disable();
    }
    
    void OnShoot(CallbackContext context)
    {
        Ray();
        ShootAnimation();
        if (!hit) return;

        EnemyHP enemy = hitInfo.collider.GetComponent<EnemyHP>();

        if (enemy!=null)

        enemy.takeDamage(damage);
    }

    void ShootAnimation()
    {

    }

    void Ray()
    {
        Ray ray = new Ray();
        ray.origin = CameraTrnsform.position;
        ray.direction = CameraTrnsform.forward;

        hit = Physics.Raycast(ray, out hitInfo);
    }
    
}
