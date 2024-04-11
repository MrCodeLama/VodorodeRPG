using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Knockback knockback;
    private void Awake()
    {
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        moveSpeed = gameManager.moveSpeed;
    }

    private void FixedUpdate()
    {
        if(knockback.gettingKnockedBack) {return;}
        rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
    }

    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }
}
