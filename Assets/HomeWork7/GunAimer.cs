using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class GunAimer : MonoBehaviour
{
    [SerializeField] private Transform CameraTrnsform;
    [SerializeField] GameObject weapon;
    [SerializeField] GameObject weaponMuzzle;

    [SerializeField] GameObject bulletPrefab;

    [SerializeField] InputAction Shoot;

    [SerializeField] float damage;

    float score;

    bool hit;
    public RaycastHit hitInfo;

    [SerializeField] Gun gun;
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        WeaponLookToo();
    }
    void OnShoot(CallbackContext context)
    {
        Ray();

        Vector3 targetPoint = hit
            ? hitInfo.point
            : CameraTrnsform.position + CameraTrnsform.forward * 100f;

        gun.Shoot(targetPoint);

        if (!hit) return;

        EnemyHP enemy = hitInfo.collider.GetComponent<EnemyHP>();

        if (enemy != null)
        {
            ScoreSystem();
        }
    }
    void WeaponLookToo()
    {
        Ray();
        if (!hit)
        {
            weapon.transform.rotation = Quaternion.LookRotation(CameraTrnsform.forward);
        }
        else
        {
            weapon.transform.LookAt(hitInfo.point);
        }
    }
    void ScoreSystem()
    {
        score += 100;
        Debug.Log("Your skore is:"+score);
    }
    void ShootAnimation()
    {
        GameObject bullet = Instantiate(bulletPrefab, weaponMuzzle.transform.position, Quaternion.identity);

        Vector3 targetPoint;

        if (hit)
            targetPoint = hitInfo.point;
        else
            targetPoint = CameraTrnsform.position + CameraTrnsform.forward * 100f;

        Vector3 direction = (targetPoint - weaponMuzzle.transform.position).normalized;

        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    void Ray()
    {
        Ray ray = new Ray();
        ray.origin = CameraTrnsform.position;
        ray.direction = CameraTrnsform.forward;

        hit = Physics.Raycast(ray, out hitInfo);
    }
    
}
