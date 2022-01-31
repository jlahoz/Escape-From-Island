using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject DeathMenuUI;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void restart()
    {
        DeathMenuUI.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        isPaused = true;
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
