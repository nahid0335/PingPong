using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComPaddle : Paddle
{
	[SerializeField]
	public Rigidbody2D ball;

	void FixedUpdate()
	{
		if (ball.velocity.x > 0.0f) {
			if (ball.position.y >= Rigidbody.position.y) {
				Rigidbody.AddForce(Vector2.up * speed);
			} else if (ball.position.y < Rigidbody.position.y) {
				Rigidbody.AddForce(Vector2.down * speed);
			}
		} else {
			if (Rigidbody.position.y > 0.0f) {
				Rigidbody.AddForce(Vector2.down * speed);
			} else if (Rigidbody.position.y < 0.0f) {
				Rigidbody.AddForce(Vector2.up * speed);
			}
		}
	}
}
