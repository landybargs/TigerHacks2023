using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int health = 100;
    public int mana = 50;
    [SerializeField]private int experience = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            health -= 20;
            if(health <= 0)
            {
                Debug.Log("You Died");
            }
        }
    }
}
