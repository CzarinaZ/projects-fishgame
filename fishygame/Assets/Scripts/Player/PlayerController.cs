using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
//using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    /*Animation Code
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    */

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        /*Animation Code
        myAnimator = GetComponent<myAnimator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        */
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void Update()
    {
        PlayerInput();
    }
    private void FixedUpdate()
    {
        /*Animation Code

        AdjustPlayerFacingDirection();
        */
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        /* Animation Code
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
        */
    }
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    /*Animation Code
    private void AdjustPlayerFacingDirection(){
        Vector3 mousePos = Input.mousePosition;
        Vector playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if(mousePos.x < playerScreenPoint.x){
            mySpriteRender.flipX = true;
        } else{
            mySpriteRender.flipX = false;
        }
    }
    */
}