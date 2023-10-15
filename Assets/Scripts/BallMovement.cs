using UnityEngine;

/// <summary>
/// movement of the ball
/// </summary>
public class BallMovement : MonoBehaviour
{
    [SerializeField] float InitialSpeed = 1;
    [SerializeField] float SpeedIncrease = 0.25f;

    public Rigidbody2D Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
		Invoke("StartBall", 2f);
	}

	void FixedUpdate()
        => Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity,InitialSpeed + (SpeedIncrease * GameManager.Instance.HitCounter));

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI") {
			PlayerBounce(collision.transform);
		}
	}

	void OnTriggerEnter2D(Collider2D collision) {
		if (transform.position.x > 0) {
			GameManager.Instance.IncreasePlayerScore();
		} else if (transform.position.x < 0) {
			GameManager.Instance.IncreaseComScore();
		}
	}

	/// <summary>
	/// add force to the ball to start the ball movement
	/// </summary>
	void StartBall()
        => AddStartingForce();

    /// <summary>
    /// get a random direction and add force to the ball
    /// </summary>
	public void AddStartingForce() {
		var randomDirectionX = Random.value < 0.5f ? -1.0f : 1.0f;
		var randomDirectionY = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

		var direction = new Vector2(randomDirectionX,randomDirectionY);
		AddForce(direction * (InitialSpeed + SpeedIncrease * GameManager.Instance.HitCounter));
	}

    /// <summary>
    /// apply the force to the ball
    /// </summary>
    /// <param name="force">force which will apply to the ball</param>
	void AddForce(Vector2 force)
		=> Rigidbody.velocity = force;

    /// <summary>
    /// set the direction of the ball
    /// </summary>
    /// <param name="hitObject">paddle</param>
    void PlayerBounce(Transform hitObject) 
    {
        ++GameManager.Instance.HitCounter;

        var ballPoaition = (Vector2)transform.position;
        var playerPosition = (Vector2)hitObject.position;

        var directionX = transform.position.x > 0 ? -1f : 1f;

        var directionY = (ballPoaition.y - playerPosition.y) / hitObject.GetComponent<Collider2D>().bounds.size.y;
        if (directionY == 0) {
            directionY = 0.25f;
        }

        Rigidbody.velocity = new Vector2(directionX,directionY) * (InitialSpeed + SpeedIncrease * GameManager.Instance.HitCounter);
    }
}
