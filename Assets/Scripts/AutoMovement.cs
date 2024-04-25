using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public float speed = 1f; 
    public float distance = 2.7f; 

    private Vector3 initialPosition;
    private bool movingRight = true;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
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

        // Движение вправо
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        // Движение влево
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void FlipSprite()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}