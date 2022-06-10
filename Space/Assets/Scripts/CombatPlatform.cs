using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CombatPlatform : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private bool mover ;
    private float randomSpeed;
    private float min;
    private float max;
    

    public bool Mover
    {
        get
        {
            return mover;
        }
        set
        {
            mover = value;
        }
    }
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        randomSpeed = Random.Range(0.5f, 1.0f);
        float objectWidth = boxCollider2D.bounds.size.x / 2;
        if (transform.position.x > 0)
        {
            min = objectWidth;
            max = ScreenCalculator.instance.Width - objectWidth;
        }
        else
        {
            min = -ScreenCalculator.instance.Width + objectWidth;
            max = -objectWidth;
        }
    }

    void Update()
    {
        if (mover)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed,max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Foots")
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }
}