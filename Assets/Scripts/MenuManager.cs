using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public float delay = 0.2f;
    public void PlayGame()
    { 
        Invoke("PlayGameDelay", delay);
    }
    void PlayGameDelay()
    {
        Application.LoadLevel("SampleScene");
    }
    public void ExitGame()
    {
        Invoke("ExitGameDelay", delay);
    }
    void ExitGameDelay()
    {
        Application.Quit();
    }

}
