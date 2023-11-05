using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    void Update()
    {
        //Changing Health and Damage values (Use for debugging)
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
       
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponentInParent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
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
        StartCoroutine(VisualIndicator(Color.red));

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;
        StartCoroutine(VisualIndicator(Color.green));

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
        Debug.Log("Entity Died!");
        Destroy(gameObject);
    }
}
