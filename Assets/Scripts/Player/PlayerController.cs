using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Subject
{
    public bool FacingLeft
    {
        get { return facingLeft;}
        set { facingLeft = value; }
    }

    [SerializeField] private PlayerHealth playerHealth;
    public static PlayerController Instance;
    [SerializeField] private GameManager gameManager;
    private float moveSpeed;
    private PlayerControls playerControls;
    private Knockback knockback;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] private Transform weaponCollider;
    private bool facingLeft = false;

    private void Awake()
    {
        Instance = this;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = gameManager.moveSpeed;
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        if (playerHealth.currentHealth <= 3)
        {
            NotifyObservers(PlayerActions.LowHP, true);
        }
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        if (movement != Vector2.zero)
        {
            NotifyObservers(PlayerActions.Move, true);
        }
        else
        {
            NotifyObservers(PlayerActions.Move, false);
        }

        if (playerControls.Combat.Attack.ReadValue<float>() == 1)
        {
            NotifyObservers(PlayerActions.Attack, true);
        }
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }
    
    private void Move()
    {
        if (knockback.gettingKnockedBack) { return;}
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    public void SetStartPosition(Vector2Int position)
    {
        transform.position = new Vector3(position.x + 0.5f, position.y+0.5f, 0);
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        mySpriteRenderer.flipX = mousePos.x < playerScreenPoint.x;
        facingLeft = mousePos.x < playerScreenPoint.x;

    }
}
