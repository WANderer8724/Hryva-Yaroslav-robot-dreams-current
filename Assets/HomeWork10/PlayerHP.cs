using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float MaxHP;
    [SerializeField] float CurrentHP;

    private void Start()
    {
        CurrentHP = MaxHP;
    }
    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
        if (CurrentHP <= 0) IsDeath();
    }

    void IsDeath()
    {
        Debug.Log("Game over");
    }

}
