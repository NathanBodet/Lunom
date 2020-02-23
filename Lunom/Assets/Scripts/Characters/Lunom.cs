using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunom : MonoBehaviour
{

    public int health; //santé courante
    int maxHealth; //maximum de coeurs possible

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        maxHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //TEST CODE
        if (Input.GetKey(KeyCode.A))
        {
            takeDamage(1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            takeDamage(-1);
        }
    }

    void takeDamage(int damage)
    {
        if(health <= damage)
        {
            //die
        } else
        {
            health -= damage;
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
