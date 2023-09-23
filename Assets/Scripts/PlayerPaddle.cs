using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : Paddle
{
	Vector2 direction;

	void Update() 
	{
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
			direction = Vector2.up;
		} else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
			direction = Vector2.down;
		} else {
			direction = Vector2.zero;
		}
	}

	void FixedUpdate()
	{
		if (direction.sqrMagnitude != 0) {
			Rigidbody.AddForce(direction * speed);
		}
	}
}
