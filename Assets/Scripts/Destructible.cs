using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] private GameObject destoyVFX;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageSource>() || other.gameObject.GetComponent<Projectile>())
        {
            GetComponent<PickupSpawner>().DropItems();
            Instantiate(destoyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
