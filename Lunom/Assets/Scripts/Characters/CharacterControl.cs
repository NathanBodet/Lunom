using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    
    public Vector2 direction; //direction du personnage en mouvement
    public float speed; //vitesse du personnage (à priori fixe)

    public bool isDash; //est en train de dasher?
    float dashTime; //temps écoulé depuis le début du dernier dash
    float dashCoolDown = 0.5f; //cooldown entre chaque début de dash(et non pas entre chaque dash)
    int dashSpriteLevel; //pour savoir si on doit afficher un nouveau sprite de dash
    Sprite spriteDash;
    public GameObject prefabDash;


    Rigidbody2D rigidBody;


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
            
            if (Time.time - dashTime < 0.1) //si le dash n'est pas fini, accélération et blocage des directions
            {
                if(Time.time - dashTime > (float)dashSpriteLevel / 100)//affichage d'un nouveau sprite de dash
                {
                    GameObject objectSpriteDash = Instantiate(prefabDash,transform,true);
                    //position du sprite : avance sur z au fur et a mesure
                    objectSpriteDash.transform.parent = null;
                    objectSpriteDash.transform.position = transform.position;
                    Vector3 dashSpritePosTemp = new Vector3(transform.position.x, transform.position.y, 12 - dashSpriteLevel);
                    objectSpriteDash.transform.position = dashSpritePosTemp;
                    //couleur du sprite : de plus en plus clair
                    SpriteRenderer sprite = objectSpriteDash.GetComponent<SpriteRenderer>();
                    float m_Red = sprite.color.g - 0.1f*(10-dashSpriteLevel);
                    float m_Green = sprite.color.g - 0.1f * (10 - dashSpriteLevel);
                    float m_Blue = sprite.color.g;// - 0.1f * (10 - dashSpriteLevel);
                    objectSpriteDash.GetComponent<SpriteRenderer>().color = new Color(m_Red, m_Green, m_Blue);

                    objectSpriteDash.GetComponent<SpriteRenderer>().sprite = spriteDash;
                    dashSpriteLevel+=1;
                }
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
                spriteDash = GetComponent<SpriteRenderer>().sprite;
                isDash = true;
                dashTime = Time.time;
                isMoving = true;
                dashSpriteLevel = 0;
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
