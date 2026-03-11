using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;

    public float speed = 30f;

    void Start()
    {
        Destroy(gameObject, 2f);
    }
    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        transform.forward = dir;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}