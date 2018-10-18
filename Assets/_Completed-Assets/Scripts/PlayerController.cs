using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	//FLOATING POINT VARIABLE TO STORE PLAYER MOVEMENT
	public float speed;
	//VARIABLE TO STORE COUNT OF PICKUP OBJECTS
	public Text countText;

	public Text winText;


	//STORE A REFERENCE TO THE Rigidbody2D COMPONENT REQUIRED TO USE 2D PHYSICS
	private Rigidbody2D rb2d;

	//	
	private int count;

	//INITIALIZES 2D REFERENCE
	void Start() 
	{
		//GET STORE REFERENCE TO Rigidbody2D COMPONENT SO WE CAN ACCESS IT
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		SetCountText ();
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

	//OnTriggerEnter2D is called whenever this object overlaps with a trigger collider.
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Pickup"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			SetCountText ();	
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();

		if (count >= 11) 
		{
			winText.text = "You Win!";
		}
	}
 	
}
