using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] float MaxHP;
    [SerializeField] float CurrentHP;
    [SerializeField] LoseWinCode LoseWin;
    [SerializeField] GameObject LoseWinPanel;

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
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        LoseWin.Win("Lose");
        LoseWinPanel.SetActive(true);
    }

}
