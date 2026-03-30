using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]float MaxHP;
    [SerializeField] float CurrentHP;
    private void Start()
    {
        CurrentHP = MaxHP;
    }
    public void takeDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0) IsDeath();
    }

    void IsDeath()
    {
        GetComponent<EnemyBehaviour>().isAlive = false;
    }
}
