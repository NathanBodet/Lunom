using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject target;
    private Vector3 targetPos;
    public float trackingSpeed;

    bool isStuck;


    void Update()
    {
        if (target != null && !isStuck)
        {
            targetPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, trackingSpeed * Time.deltaTime);
        }
    }

    void Stuck(Vector2 stuckCoordinates) //permet de bloquer la camera à des coordonnées précises (certaines rooms)
    {
        isStuck = true;
        transform.position = stuckCoordinates;
    }

    void Unstuck() //débloque la caméra qui va suivre la target de nouveau
    {
        isStuck = false;
    }
}
