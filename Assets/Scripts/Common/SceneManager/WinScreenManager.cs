using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public void goToStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
