using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
    private float backGroundPosition;
    private float distance = 10.24f;
    
    // Start is called before the first frame update
    void Start()
    {
        backGroundPosition = transform.position.y;
        FindObjectOfType<Planets>().CreatPlanet(backGroundPosition);

    }

    // Update is called once per frame
    void Update()
    {
        if (backGroundPosition + distance < Camera.main.transform.position.y)
        {
            MoveBackGround();
        }
    }

    void MoveBackGround()
    {
        backGroundPosition += (distance * 2);
        FindObjectOfType<Planets>().CreatPlanet(backGroundPosition);
        Vector2 newPosition = new Vector2(0, backGroundPosition);
        transform.position = newPosition;
    }
}
