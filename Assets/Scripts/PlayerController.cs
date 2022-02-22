using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class PlayerController : MonoBehaviour
    {
    //Components
    Rigidbody2D rb;
    
    //player
    [Header("Player Movement:")] 
    public float walkSpeed = 4f;
    public float speedLimit = 0.7f;
    public float inputHorizontal;
    public float inputVertical;


    // Start is called before the first frame update
    void Start()
    {
        //gets the rigibody of the gameobject.
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks the inputs and makes it 1, -1 or 0 depending on the button pressed.
        //Horizontal and Vertical are two things that depending the settings which button is bind to it.
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //goes to check what value is in these variables and adding the force to move the player
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if (inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimit;
                inputVertical *= speedLimit;
            }
            
            rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed);
        }
        else
        {
                        rb.velocity = new Vector2(0f, 0f);
        }
        
    }
}
}
