using UnityEngine;
using System.Collections;

public class AutoMovement : MonoBehaviour
{
    public float speed = 1f; 
    public float distance = 2.7f; 
    public float highSpeed = 15f; 
    public float delayBeforeHighSpeed = 5f; 
    public float fallDistance = 100f; 

    private Vector3 initialPosition;
    private bool movingRight = true;
    private bool moveDown = false;
    private bool falling = false;
    private float fallStartPosition;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(StartHighSpeedAfterDelay());
    }

    void Update()
    {
        if (falling)
        {
            transform.Translate(Vector2.down * highSpeed * Time.deltaTime);

            if (transform.position.y <= fallStartPosition - fallDistance)
            {
                falling = false;
                moveDown = false;
            }
        }
        else if (moveDown)
        {
            transform.Translate(Vector2.down * highSpeed * Time.deltaTime);
        }
        else
        {
            if (movingRight && transform.position.x >= initialPosition.x + distance)
            {
                movingRight = false;
                FlipSprite();
            }
            else if (!movingRight && transform.position.x <= initialPosition.x)
            {
                movingRight = true;
                FlipSprite();
            }

            if (movingRight)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
    }

    void FlipSprite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    IEnumerator StartHighSpeedAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeHighSpeed);
        moveDown = true;
        fallStartPosition = transform.position.y;
        falling = true;
    }
}
