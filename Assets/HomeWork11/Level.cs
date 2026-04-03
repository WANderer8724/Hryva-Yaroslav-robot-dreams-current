using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Level : MonoBehaviour
{
    float score;
    public void ScoreSystem()
    {
        score += 100;
        Debug.Log("Your skore is:" + score);
        Win();
    }

    public void Win()
    {
        if (score >= 2000)
        {
            Debug.Log("You Win!!");
        }
    }
}
