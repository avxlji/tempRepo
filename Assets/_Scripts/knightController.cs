﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightController : MonoBehaviour
{

    public GameObject Player;
    float distance;

    //defining aatributes for this class

    float speed = 40.0f; // spped of the knight
    float rotSpeed = 80.0f; // rotation speed of knight
    float rotation = 0.0f;
    float gravity = 8.0f; // the effect of gravity on knight

    Vector3 moveDir = Vector3.zero; // knight would be still once game starts until it is moved

    CharacterController controller; //defining a characterController type variable
    Animator anim; // defining an animator type variable

    


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); //assigning characterController component to the knight(player)
        anim = GetComponent<Animator>(); //assigning animator component to the knight(player)

        

    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(transform.position, Player.transform.position);
        GetInput();
    }

    void GetInput()
    {
       
            if (distance > 1.0f) // if there is a left click on mouse
            {
                if (anim.GetBool("running") == true) // if the player is running
                {
                    anim.SetBool("running", false); // set the running paramter to false (stop the player)
                    anim.SetInteger("condition", 0); // make the player idle
                }
                if (anim.GetBool("running") == false)
                {
                    Attacking(); // whenever this is the case, just call the attacking method
                }
                
            }
        }
    


    void Attacking() // creating a function for attacking
    {
        StartCoroutine(AttackingRoutine());
        
    }

    IEnumerator AttackingRoutine()
    {
        anim.SetBool("attacking", true); // setting attacking parameter to true
        anim.SetInteger("condition", 2); // this sets the condition parameter to 2 which triggers the attacking animation
        yield return new WaitForSeconds(1); // we wait for a second before we attack everytime
        anim.SetInteger("condition", 0); //after we attack, we idle
        anim.SetBool("attacking", false); // we are not attacking anymore
    }
}
