using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
       
    }

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= amount;

        //Death on health <= 0
        if(health <= 0 )
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        this.health -= amount;

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if(health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }       
    }
    private void Die()
    {
        Debug.Log("You Died!");
        Destroy(gameObject);
    }
}
