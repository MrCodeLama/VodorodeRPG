using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public Transform movePoint;
    public Animator animator;
    public LayerMask whatStopsMovement;
    public int MaxHealth;
    public int currentHealth;
    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        healthbar.setMaxHealth(MaxHealth);
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        currentHealth = healthbar.getCurrentHealth();
        if (currentHealth == 0)
        {
            BackToMenu();
        }

        
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
        {
            
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                //animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
                //animator.SetFloat("Vertical", 0);

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),
                        0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                //animator.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
                //animator.SetFloat("Horizontal", 0);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f),
                        0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
            else
            {
                //animator.SetFloat("Vertical", 0);
                //animator.SetFloat("Horizontal", 0);
            }
        }
    }

    public void SetStartPosition(Vector2Int position)
    {
        transform.position = new Vector3(position.x + 0.5f, position.y+0.5f, 0);
    }

    public void BackToMenu()
    {
        Invoke("BackToMenuDelay", 0.2f);
        Time.timeScale = 1f;

    }
    void BackToMenuDelay()
    {
        Application.LoadLevel("Menu");
        Time.timeScale = 1f;

    }
}
