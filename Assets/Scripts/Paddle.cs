using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	protected Rigidbody2D Rigidbody;
	public float speed = 10.0f;

	void Awake()
	{
		Rigidbody = GetComponent<Rigidbody2D>();
	}

	public void ResetPosition()
	{
		Rigidbody.velocity = Vector3.zero;
		Rigidbody.position = new Vector2(Rigidbody.position.x, 0.0f);
	}
}
