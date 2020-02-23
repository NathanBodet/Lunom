using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeart : MonoBehaviour
{

    public int healthLevel;
    Lunom player;

    private void Start()
    {
        player = GameObject.Find("Lunom").GetComponent<Lunom>();
        transform.SetParent(GameObject.Find("Canvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health < healthLevel)
        {
            GetComponent<Image>().enabled = false;
        } else
        {
            GetComponent<Image>().enabled = true;
        }
        
    }

    public void SetLevel(int level)
    {
        healthLevel = level;
        Vector2 healthPos = new Vector2(-30 + 60 * level, 400);
        GetComponent<RectTransform>().anchoredPosition = healthPos;
    }
}
