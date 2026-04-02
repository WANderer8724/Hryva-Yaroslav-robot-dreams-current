using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 direction;

    public float speed = 30f;
        [SerializeField] float damage = 10f;

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
        EnemyHP enemy = other.GetComponent<EnemyHP>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
        }

        PlayerHP player = other.GetComponent<PlayerHP>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}