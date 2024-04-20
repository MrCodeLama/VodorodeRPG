using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpawnPoint;

    public Animator myAnimator;

    private void Awake()
    {
        //myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        myAnimator.SetTrigger("Fire");
        GameObject newArrow =
            Instantiate(arrowPrefab, arrowSpawnPoint.position, ActiveWeapon.Instance.transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateWeaponInfo(weaponInfo);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
