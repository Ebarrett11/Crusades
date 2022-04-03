﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMoveScript : MonoBehaviour {

    //make our projectile move

    public Vector2 speed = new Vector2(10, 10);

    //movement direction
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    private Rigidbody2D rigidbodyComponent; //connect to Unity's RB
	
    // Use this for initialization
	void FixedUpdate () {
		if(rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

            //apply movement
            rigidbodyComponent.velocity = movement;
       
	}
	
	// Update is called once per frame
	void Update () {
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);
	}



}