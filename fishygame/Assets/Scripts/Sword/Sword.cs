using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sword : MonoBehaviour
{
    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
        myAnimator = GetComponent<Animator>();
        playerController = GetComponentInParent<PlayerController>();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();
    }
    private void Update()
    {
        MouseFollowWithOffset();
    }
    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;

        if(mousePos.x <playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 180, -angle);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
