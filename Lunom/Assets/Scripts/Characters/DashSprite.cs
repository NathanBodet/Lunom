using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSprite : MonoBehaviour
{

    float lifetime;
    // Start is called before the first frame update
    void Start()
    {
        lifetime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lifetime > 0.1)
        {
            Destroy(gameObject);
        }
    }
}
