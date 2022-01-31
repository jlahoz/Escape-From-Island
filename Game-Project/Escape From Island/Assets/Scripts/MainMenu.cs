using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    public void play()
    {
        SceneManager.LoadScene("Game");
    }

    public void controls()
    {
        SceneManager.LoadScene("controlsMenu");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
