using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 22f;
    [SerializeField] private GameObject particleOnHitPrefabVFX;
    [SerializeField] private bool isEnemyProjectile = false;
    [SerializeField] private float projectileRange = 10f;
    
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        MoveToProjectile();
        DetectFireDistance();
    }

    public void UpdateProjectileInfo(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructible indestructible = other.gameObject.GetComponent<Indestructible>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        
        if (!other.isTrigger && (enemyHealth || indestructible || player))
        {
            if ((player && isEnemyProjectile) || (enemyHealth && !isEnemyProjectile))
            {
                player?.TakeDamage(1, transform);
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            } else if (!other.isTrigger && indestructible)
            {
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }

    private void DetectFireDistance()
    {
        if (Vector3.Distance(transform.position, startPosition) > projectileRange)
        {
            Destroy(gameObject);
        }
    }

    private void MoveToProjectile()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
    }
}
