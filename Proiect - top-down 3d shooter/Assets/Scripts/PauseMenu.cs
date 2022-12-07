using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public static string menu = "Menu";

    void Start()
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

    }

    

    void PauseGame()
    {
        //only pausing actions that scale with time, music or others will not be pause, will add those in later versions
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseMenuUI.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
            //
        }
    }
    public void Resume()
    {
        gameIsPaused = !gameIsPaused;
        PauseGame();
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        //Time.timeScale = 1;
        //SceneManager.LoadScene(menu);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
