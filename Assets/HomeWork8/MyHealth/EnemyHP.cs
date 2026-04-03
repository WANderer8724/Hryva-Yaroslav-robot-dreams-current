using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]float MaxHP;
    [SerializeField] float CurrentHP;

    [SerializeField] Level level;
    private void Start()
    {
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
        level.ScoreSystem();
        GetComponent<EnemyBehaviour>().isAlive = false;
    }
}
