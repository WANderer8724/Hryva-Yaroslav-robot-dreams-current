using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public float cooldown = 3f;
    private float timer;

    public GameObject Enemy;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemy();
            timer = cooldown; // перезапуск таймера
        }
    }

    void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
