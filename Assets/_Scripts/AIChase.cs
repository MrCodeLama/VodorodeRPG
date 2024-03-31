using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    private float distance;
    public Transform movePoint;
    public LayerMask whatStopsMovement;
    public int MaxHealth;
    public int currentHealth;
    
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        distance = Vector2.Distance(transform.position, player.transform.position);
    }
}
