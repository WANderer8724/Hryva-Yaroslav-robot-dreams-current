using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]float MaxHP;
    [SerializeField] float CurrentHP;

    [SerializeField] Level level;

    [SerializeField] SpawnerEnemy SpawnerEnemy;
    private void Start()
    {
        SpawnerEnemy = FindObjectOfType<SpawnerEnemy>();
        level = FindObjectOfType<Level>();
        CurrentHP = MaxHP;
    }
    public void takeDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0) IsDeath();
    }

    void IsDeath()
    {
        SpawnerEnemy.EnemyDead();
        level.ScoreSystem();
        GetComponent<EnemyBehaviour>().isAlive = false;
    }
}
