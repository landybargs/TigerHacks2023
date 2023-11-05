using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    public float walkSpeed = .8f;




    public float health = 1;

    public float Health{
        set{
            health = value;
            if(health <=0){
                Defeated();
            }
        }
        get{
            return health;
        }
    }


/*
    private void FixedUpdate(){
        rb.velocity = new Vector2(walkSpeed * Vector2.right.x, rb.velocity.y);
    }
*/
    private void Start(){
        animator = GetComponent<Animator>();
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy(){
        Destroy(gameObject);
    }

}
