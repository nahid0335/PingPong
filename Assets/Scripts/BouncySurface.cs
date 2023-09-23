using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
	public float bounceStrength = 50.0f;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		var ball = collision.gameObject.GetComponent<Ball>();

		if (ball is not null) {
			ball.speed *= bounceStrength;
		}
	}
}
