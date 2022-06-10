using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed ;

    private float acceleration ;

    private float maxSpeed;

    private bool move  ;
    
    // Start is called before the first frame update
    void Start()
    {
        move = true;
        if (Options.ReadEasy() == 1)
        {
            speed = 0.3f;
            acceleration = 0.03f;
            maxSpeed = 1.5f;
        }
        if (Options.ReadMedium() == 1)
        {
            speed = 0.5f;
            acceleration = 0.05f;
            maxSpeed = 2.0f;
        }

        if (Options.ReadHard() == 1)
        {
            speed = 0.8f;
            acceleration = 0.08f;
            maxSpeed = 2.5f;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            MoveCamera();
        }


    }

    void MoveCamera()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        speed += acceleration * Time.deltaTime;
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void GameOver()
    {
        move = false;
    }
}
