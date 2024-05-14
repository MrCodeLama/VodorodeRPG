using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameIsPaused = false;
    public int maxHP = 20;
    public float moveSpeed = 4f;
    public int killedMobs = 0;
    public float delay = 0.2f;
    [SerializeField]private Animator animator;
    public int coins = 0;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    
    private void GameOver()
    {
        animator.SetBool("_isAlive", false);
        BackToMenu();
    }
    
    private void BackToMenu()
    {
        Invoke("BackToMenuDelay", delay);
        Time.timeScale = 1f;

    }
    private void BackToMenuDelay()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1f;

    }
}
