using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseWin : MonoBehaviour
{
    [SerializeField] private TMP_Text text;


    public void Win(string isWIN)
    {
        if (isWIN == "Win")
        {
            text.text = "You Win";
        }
        if (isWIN == "Lose")
        {
            text.text = "You Lose";
        }
    }

    public void Restart()
    {
        //перезагрузить сцену 
    }
}
