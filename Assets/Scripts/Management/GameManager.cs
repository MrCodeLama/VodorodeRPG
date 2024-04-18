using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentHP = 20;
    public bool GameIsPaused = false;
    public int maxHP = 20;
    public float moveSpeed = 4f;
    public int killedMobs = 0;
    public float delay = 0.2f;
    [SerializeField]private Animator animator;
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

    public void addHP(int amount=2)
    {
        amount = 2;
        if (currentHP + amount >= maxHP)
        {
            currentHP = maxHP;
        }
        else
        {
            currentHP += amount;
        }
    }
    
    public void reduceHP(int amount)
    {
        if (currentHP == amount)
        {
            GameOver();
        }
        else
        {
            currentHP -= amount;
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
