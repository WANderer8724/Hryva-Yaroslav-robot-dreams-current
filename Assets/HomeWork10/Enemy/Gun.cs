using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject FleshPref;


    public void Shoot(Vector3 targetPoint)
    {
        IndicationEffect();
        GameObject bullet = Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);

        Vector3 direction = (targetPoint - muzzle.position).normalized;

        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    void IndicationEffect()
    {
        Instantiate(FleshPref, muzzle.position, muzzle.rotation);
    }
}