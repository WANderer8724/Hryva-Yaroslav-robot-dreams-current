using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject bulletPrefab;


    public void Shoot(Vector3 targetPoint)
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        Vector3 direction = (targetPoint - muzzle.position).normalized;

        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}