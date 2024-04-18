using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameManager.GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameManager.GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameManager.GameIsPaused = true;
    }

    public void BackToMenu()
    {
        Invoke("BackToMenuDelay", gameManager.delay);
        Time.timeScale = 1f;
    }
    void BackToMenuDelay()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1f;
    }
}
