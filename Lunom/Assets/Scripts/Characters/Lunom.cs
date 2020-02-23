using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunom : MonoBehaviour
{

    public int health; //santé courante
    int maxHealth; //maximum de coeurs possible
    public GameObject healthpref;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        HealthUp(3);
    }

    // Update is called once per frame
    void Update()
    {
        //TEST CODE
        if (Input.GetKey(KeyCode.A))
        {
            TakeDamage(1);
        }
        if (Input.GetKey(KeyCode.E))
        {
            TakeDamage(-1);
        }
    }

    void TakeDamage(int damage)
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

    void HealthUp(int healthUp)//increases max health by healthUp
    {
        
        for(int i = 0; i< healthUp; i++)
        {
            GameObject healthTemp = Instantiate(healthpref);
            healthTemp.GetComponent<HealthHeart>().SetLevel(maxHealth + i + 1);
        }
        maxHealth += healthUp;
    }
}
