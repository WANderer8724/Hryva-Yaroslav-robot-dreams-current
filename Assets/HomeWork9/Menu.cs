using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartBatton(int numbScen)
    {
        SceneManager.LoadScene(numbScen);
    }
    public void ExidBatton()
    {
        Application.Quit();
        Debug.Log("Game Over");
    }
}
