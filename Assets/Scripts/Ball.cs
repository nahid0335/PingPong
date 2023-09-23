using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float speed = 200.0f;

	[SerializeField]
	Rigidbody2D Rigidbody;

	void Awake()
	{
		Rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		ResetPosition();
		AddStartingForce();
	}

	public void AddStartingForce()
	{
		var randomDirectionX = Random.value < 0.5f ? -1.0f : 1.0f;
		var randomDirectionY = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

		var direction = new Vector2(randomDirectionX, randomDirectionY);
		AddForce(direction * speed);
	}

	public void AddForce(Vector2 force)
	{
		Rigidbody.AddForce(force);
	}

	public void ResetPosition()
	{
		Rigidbody.position = Vector3.zero;
		Rigidbody.velocity = Vector3.zero;
		speed = 200.0f;
	}
}
