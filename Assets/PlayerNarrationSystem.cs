using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerNarrationSystem : MonoBehaviour, IObserver
{
    [SerializeField] private Subject playerSubject;
    [SerializeField] private AudioSource walk;
    [SerializeField] private AudioSource attack;
    [SerializeField] private AudioSource lowHP;
    public void OnNotify(PlayerActions action, bool param)
    {
        switch (action)
        {
            case PlayerActions.Move:
                if (param)
                {
                    PlayIf(walk);
                }
                else
                {
                    walk.Stop();
                }
                break;
            case PlayerActions.Attack:
                PlayIf(attack);
                break;
            case PlayerActions.LowHP:
                PlayIf(lowHP);
                break;
            default:
                break;
        }
    }

    private void PlayIf(AudioSource source)
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
    
    private void OnEnable()
    {
        playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        playerSubject.RemoveObserver(this);
    }
}
