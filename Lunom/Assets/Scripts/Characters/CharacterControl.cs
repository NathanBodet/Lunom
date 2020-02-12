using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    
    protected Vector2 direction; //direction du personnage en mouvement
    public float speed; //vitesse du personnage (à priori fixe)

    public bool isDash; //est en train de dasher?
    float dashTime; //temps écoulé depuis le début du dernier dash
    float dashCoolDown = 0.5f; //cooldown entre chaque début de dash(et non pas entre chaque dash)

    public Rigidbody2D rigidBody;


    // Start is called before the first frame update
    void Start()
    {
        isDash = false;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
    }

    public void Move()
    {
        
        if (isDash) {

            GetComponent<Animator>().SetBool("isMoving", false);
            if (Time.time - dashTime < 0.1) //si le dash n'est pas fini, accélération et blocage des directions
            {
                rigidBody.velocity = direction.normalized * speed * 4;
            } else // sinon fin du dash et libération des mouvements
            {
                isDash = false;
                rigidBody.velocity = direction.normalized * speed;
            }
        } else // application normale des mouvements au rigidbody
        {
            rigidBody.velocity = direction.normalized * speed;
        }
    }

    private void GetInput()
    {

        if (!isDash) //seulement si on ne dash pas
        {
            bool isMoving = false;
            //inputs directionnels
            direction = Vector2.zero;
            if (Input.GetKey(KeyCode.Z))
            {
                direction += Vector2.up;
                GetComponent<Animator>().SetInteger("direction", 3);
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.Q))
            {
                direction += Vector2.left;
                GetComponent<Animator>().SetInteger("direction", 2);
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
                GetComponent<Animator>().SetInteger("direction", 1);
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
                GetComponent<Animator>().SetInteger("direction", 4);
                isMoving = true;
            }
            if (Input.GetKey(KeyCode.C) && Time.time-dashTime > dashCoolDown) //on vérifie que le cooldown est terminé
            {
                isDash = true;
                dashTime = Time.time;
                isMoving = true;
            }
            if (isMoving)
            {
                GetComponent<Animator>().SetBool("isMoving", true);
            } else
            {
                GetComponent<Animator>().SetBool("isMoving", false);
            }
        }


    }
}
