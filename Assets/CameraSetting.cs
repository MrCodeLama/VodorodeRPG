using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraSetting : MonoBehaviour
{
    [SerializeField]private CinemachineVirtualCamera camera;

    private void Awake()
    {
        camera.Follow = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
}
