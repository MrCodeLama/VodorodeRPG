using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewWeapon")]
public class WeaponInfo : ScriptableObject
{
    public GameObject weaponPrefab;
    public float weaponCooldown;
    public int weaponDamage;
    public float weaponRange;
}
