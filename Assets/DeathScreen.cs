using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;
    public void Death()
    {
        Time.timeScale = 0f;
        deathScreenUI.SetActive(true);
        GameObject.FindWithTag("IdleAudio").SetActive(false);
        GameObject.FindWithTag("LowHPAudio").SetActive(false);
    }
}
