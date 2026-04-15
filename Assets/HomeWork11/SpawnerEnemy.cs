using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    public float cooldown = 3f;
    private float timer;
    [SerializeField] private int MAXenemys;
    private int CurentEnemys;

    public GameObject Enemy;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && CurentEnemys < MAXenemys)
        {
            SpawnEnemy();
            CurentEnemys++;
            timer = cooldown; // перезапуск таймера
        }
    }
    public void EnemyDead()
    {
        CurentEnemys--;
    }
    void SpawnEnemy()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
