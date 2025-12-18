using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private Transform weaponCollider;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;
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
        weaponCollider.gameObject.SetActive(true);

        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity);
        slashAnim.transform.parent = this.transform.parent;
    }
    public void DoneAttackingAnimEvent()
    {
        weaponCollider.gameObject.SetActive(false);
    }
    public void SwingUpFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

// Add when I do animations
        /*if(playerController.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
        */
    }
    public void SwingDownFlipAnimEvent()
    {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //add when I do animations
        /*
        if (playerController.FacingLeft)
        {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        } 
        */
    }
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;

        if(mousePos.x <playerScreenPoint.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 180, -angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0,-180,0);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
