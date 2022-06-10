using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Joystick joystick;
    private JoystickButton joystickButton;
    private Animator animator;
    private Vector2 velocity;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float jumpingPower;
    [SerializeField] private int jumpLimit = 3;
    private int jumps;
    private bool jumping;
    

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButton = FindObjectOfType<JoystickButton>();
    }

    void Update()
    {
#if UNITY_EDITOR
                KeywordControl();
#else
              JoystickControl();
#endif
    }

    void KeywordControl()
    {
        float movementInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if (movementInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk",true);
            scale.x = 0.3f;
            
        }else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk",true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk",false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
        
        if (Input.GetKeyDown("space"))
        {
            StartJump();
        }

        if (Input.GetKeyUp("space"))
        {
            FinishJump();
        }
    }

    public void JoystickControl()
    {
        float movementInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        if (movementInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk",true);
            scale.x = 0.3f;
            
        }else if (movementInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, movementInput * speed, acceleration * Time.deltaTime);
            animator.SetBool("Walk",true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
            animator.SetBool("Walk",false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);
        if (joystickButton.keyPressed == true && jumping == false)
        {
            jumping = true;
            StartJump();
        }
        if (joystickButton.keyPressed == false && jumping == true)
        {
            jumping = false;
            FinishJump();
        }
    }

    void StartJump()
    {
        if (jumps < jumpLimit)
        {
            rigidbody2D.AddForce(new Vector2(0,jumpingPower),ForceMode2D.Impulse);
            animator.SetBool("Jump",true);
            FindObjectOfType<SliderController>().SliderAmaunt(jumpLimit,jumps);
        }
       
    }

    void FinishJump()
    {
        animator.SetBool("Jump",false);
        jumps++;
        FindObjectOfType<SliderController>().SliderAmaunt(jumpLimit,jumps);

    }

    public void ResetJump()
    {
        jumps = 0;
        FindObjectOfType<SliderController>().SliderAmaunt(jumpLimit,jumps);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            FindObjectOfType<GameController>().GameOver();
        }
    }

    public void PlayerDie()
    {
        Destroy(gameObject);
    }
}
