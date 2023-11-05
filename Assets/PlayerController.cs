using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    Vector2 movementInput;

    Rigidbody2D rb;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    Animator animator;

    SpriteRenderer spriteRenderer;

    public SwordAttack swordAttack;

    public ContactFilter2D movementFilter;

    public float moveSpeed = 1f;

    public float maxSpeed = 2f;

    public float idleFriction = .1f;

    public float collisionOffset = 0.05f;

    bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(canMove){
        if (movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);
            if(!success){
                success = TryMove(new Vector2(movementInput.x,0));
            }

            if(!success){
                success = TryMove(new Vector2(0,movementInput.y));
            }

            animator.SetBool("isMoving", success);
        }else{
            animator.SetBool("isMoving", false);
        }
        //set direction of sprite to mvoement direction
        if(movementInput.x < 0){
            spriteRenderer.flipX = true;
        }else if(movementInput.x > 0){
            spriteRenderer.flipX = false; 
        }
        }

    }

    private bool TryMove(Vector2 direction){
        if(direction!=Vector2.zero){
        int count = rb.Cast(
        direction,
        movementFilter,
        castCollisions,
        moveSpeed * Time.fixedDeltaTime + collisionOffset);

        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        }else{
            return false;
        }
        }else{
            //cant move if theres no direction
            return false;
        }

    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnFire(){
        animator.SetTrigger("swordAttack");
    }

    public void SwordAttack(){
        LockMovement();
        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        }else{
            swordAttack.AttackRight();
        }
        
    }

    public void EndSwordAttack(){
        UnlockMovement();
        swordAttack.StopAttack();
    }


    public void LockMovement(){
        canMove = false;
    }

    public void UnlockMovement(){
        canMove = true;
    }


}
