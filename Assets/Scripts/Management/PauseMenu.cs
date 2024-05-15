using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private GameObject minimap;
    public AudioSource sound;
    public GameObject notWanted;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        minimap = GameObject.FindWithTag("minimap");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {sound.Play();
            if (gameManager.GameIsPaused)
            {
                Resume();

                
            }
            else
            {
                Pause();
                notWanted.SetActive(false);
            }
        }
    }

    public void Resume()
    {sound.Play();
        minimap.SetActive(true);
        notWanted.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameManager.GameIsPaused = false;
    }

    void Pause()
    {
        minimap.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameManager.GameIsPaused = true;
    }

    public void BackToMenu()
    {
        sound.Play();
        Invoke("BackToMenuDelay", gameManager.delay);
        Time.timeScale = 1f;
    }
    void BackToMenuDelay()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1f;
    }
}
