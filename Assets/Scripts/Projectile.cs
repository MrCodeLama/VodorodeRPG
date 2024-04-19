using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;

    private void Update()
    {
        MoveToProjectile();
    }

    private void MoveToProjectile()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
    }
}
