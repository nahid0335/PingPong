using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float InitialSpeed = 1;
    [SerializeField] float SpeedIncrease = 0.25f;
    [SerializeField] Text PlayerScore;
    [SerializeField] Text ComScore;

    int HitCounter;
    Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
		Invoke("StartBall", 2f);
	}

	private void FixedUpdate() 
    {
        Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, InitialSpeed + SpeedIncrease * HitCounter);
	}

    void StartBall()
    {
        AddStartingForce();
        // Rigidbody.velocity = new Vector2(-1,0) * (InitialSpeed + SpeedIncrease * HitCounter);
    }

	public void AddStartingForce() {
		var randomDirectionX = UnityEngine.Random.value < 0.5f ? -1.0f : 1.0f;
		var randomDirectionY = UnityEngine.Random.value < 0.5f ? UnityEngine.Random.Range(-1.0f,-0.5f) : UnityEngine.Random.Range(0.5f,1.0f);

		var direction = new Vector2(randomDirectionX,randomDirectionY);
		AddForce(direction * (InitialSpeed + SpeedIncrease * HitCounter));
	}

	public void AddForce(Vector2 force)
		=> Rigidbody.velocity = force;

	void ResetBall()
    {
        Rigidbody.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        HitCounter = 0;
        Invoke("StartBall", 2f);
    }

    void PlayerBounce(Transform hitObject) 
    {
        ++HitCounter;

        var ballPoaition = (Vector2)transform.position;
        var playerPosition = (Vector2)hitObject.position;

        var directionX = 0.0f;
        if (transform.position.x > 0) {
            directionX = -1;
        } else {
            directionX = 1;
        }

        var directionY = (ballPoaition.y - playerPosition.y) / hitObject.GetComponent<Collider2D>().bounds.size.y;
        if (directionY == 0) {
            directionY = 0.25f;
        }

        Debug.Log(InitialSpeed + SpeedIncrease * HitCounter);
        Rigidbody.velocity = new Vector2(directionX,directionY) * (InitialSpeed + SpeedIncrease * HitCounter);
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI") {
            PlayerBounce(collision.transform);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (transform.position.x > 0) {
            ResetBall();
            PlayerScore.text = (int.Parse(PlayerScore.text) + 1).ToString();
        } else if (transform.position.x < 0) {
            ResetBall();
            ComScore.text = (int.Parse(ComScore.text) + 1).ToString();
        }
	}
}
