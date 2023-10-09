using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float InitialSpeed = 1;
    [SerializeField] float SpeedIncrease = 0.25f;

    
    public Rigidbody2D Rigidbody;
    public GameManager gameManager;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
		Invoke("StartBall", 2f);
	}

	private void FixedUpdate() 
    {
        Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity, InitialSpeed + SpeedIncrease * gameManager.HitCounter);
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
		AddForce(direction * (InitialSpeed + SpeedIncrease * gameManager.HitCounter));
	}

	public void AddForce(Vector2 force)
		=> Rigidbody.velocity = force;

	

    void PlayerBounce(Transform hitObject) 
    {
        ++gameManager.HitCounter;

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

        Debug.Log(InitialSpeed + SpeedIncrease * gameManager.HitCounter);
        Rigidbody.velocity = new Vector2(directionX,directionY) * (InitialSpeed + SpeedIncrease * gameManager.HitCounter);
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI") {
            PlayerBounce(collision.transform);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (transform.position.x > 0) {
			gameManager.IncreasePlayerScore();
        } else if (transform.position.x < 0) {
            gameManager.IncreaseComScore();
        }
	}
}
