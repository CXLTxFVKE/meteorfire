using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerMovement : Unit {
	private Rigidbody2D rb;       //Store a reference to the Rigidbody2D
	public int playerlevel;
	public int killcount;
	[SerializeField]



	void Start()
	{
		// store player rigid body as rb
		playerlevel = 1;
		rb = GetComponent<Rigidbody2D> ();
	}


	void FixedUpdate()
	{
		// turn horizontal and vertical movement axes set in the editor into floats movex and movey, use those to create vector2 of overall desired movement
		float movex = Input.GetAxis ("Horizontal");
		float movey = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (movex, movey);
		// add force to the rigid body using the movment vector, and multiply it by speed
		rb.AddForce (movement * movespeed); //maximumSpeed);

		//if the rigid bodies speed is too high(set in editor) then set it back to the limit
		if(rb.velocity.magnitude > maxspeed)
		{
			rb.velocity = rb.velocity.normalized * maxspeed;
		}


		//rotate to mouse position
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


			

	}
}

