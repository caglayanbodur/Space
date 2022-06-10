using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    private PolygonCollider2D polygonCollider2D;
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
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        if (Options.ReadEasy() == 1)
        {
            randomSpeed = Random.Range(0.2f, 0.8f);

        }
        if (Options.ReadMedium() == 1)
        {
            randomSpeed = Random.Range(0.5f, 1.0f);

        }

        if (Options.ReadHard() == 1)
        {
            randomSpeed = Random.Range(0.8f, 1.5f);

        }
        
        float objectWidth = polygonCollider2D.bounds.size.x / 2;
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
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMovement>().ResetJump();
        }
    }
}
