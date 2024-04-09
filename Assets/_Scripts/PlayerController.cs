using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform movePoint;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask whatStopsMovement;
    [SerializeField] private GameManager gameManager;
    
    void Start()
    {
        movePoint.parent = null;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Shops")
        {
            Debug.Log("543");
        }
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, gameManager.moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.01f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("Vertical", 0);

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),
                        0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                animator.SetFloat("Vertical", 1f);
                animator.SetFloat("Horizontal", 0);
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f),
                        0.2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
            else
            {
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Horizontal", 0);
            }
        }
    }

    public void SetStartPosition(Vector2Int position)
    {
        transform.position = new Vector3(position.x + 0.5f, position.y+0.5f, 0);
    }
}
