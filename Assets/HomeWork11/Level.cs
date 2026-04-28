using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Level : MonoBehaviour
{
    float score;
    [SerializeField] LoseWinCode LoseWin;
    [SerializeField] GameObject LoseWinPanel;
    public void ScoreSystem()
    {
        score += 100;
        Debug.Log("Your skore is:" + score);
        Win();
    }

    public void Win()
    {
        if (score >= 200)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            LoseWin.Win("Win");
            LoseWinPanel.SetActive(true);
        }
    }
}
