using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private float swordAttackCD = 0.5f;
    private Transform weaponCollider;
    private Animator myAnimator;
    
    private GameObject slashAnim;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();
        slashAnimSpawnPoint = GameObject.Find("SlashSpawnPoint").transform;
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }
    
    public void Attack()
    {
        myAnimator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
        StartCoroutine(AttackCDRoutine());
    }

    private IEnumerator AttackCDRoutine()
    {
        yield return new WaitForSeconds(swordAttackCD);
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
    
    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (PlayerController.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
    
    public void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (PlayerController.Instance.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, (mousePos.x < playerScreenPoint.x)? -180 : 0, angle);
        weaponCollider.transform.rotation = Quaternion.Euler(0, (mousePos.x < playerScreenPoint.x)? -180 : 0, 0);
    }
}
