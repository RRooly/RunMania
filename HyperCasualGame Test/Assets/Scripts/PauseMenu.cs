using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;

    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
    }

    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void GameQuit()
    {
        Application.Quit();
    }


}
