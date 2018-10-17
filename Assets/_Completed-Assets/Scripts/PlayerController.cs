using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//FLOATING POINT VARIABLE TO STORE PLAYER MOVEMENT
	public float speed;

	//STORE A REFERENCE TO THE Rigidbody2D COMPONENT REQUIRED TO USE 2D PHYSICS
	private Rigidbody2D rb2d;

	//INITIALIZES 2D REFERENCE
	void Start() 
	{
		//GET STORE REFERENCE TO Rigidbody2D COMPONENT SO WE CAN ACCESS IT
		rb2d = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{
		// STORES CURRENT HORIZONTAL INPUT IN FLOAT moveHorizontal
		float moveHorizontal = Input.GetAxis ("Horizontal");

		// STORES CURRENT VERTICAL INPUT IN FLOAT moveVertical
		float moveVertical = Input.GetAxis ("Vertical");

		// NEW VECTOR2 VARIABLE movement, USES TWO FLOATS
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		// USE ADDForce FUNCTION TO CREATE 2D PHYSICS ON RigidBody2D COMPONENT 
		rb2d.AddForce (movement * speed);
	}
}
