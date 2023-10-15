using UnityEngine;

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

	private void FixedUpdate()
        => Rigidbody.velocity = Vector2.ClampMagnitude(Rigidbody.velocity,InitialSpeed + (SpeedIncrease * GameManager.Instance.HitCounter));

	void StartBall()
        => AddStartingForce();

	public void AddStartingForce() {
		var randomDirectionX = Random.value < 0.5f ? -1.0f : 1.0f;
		var randomDirectionY = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) : Random.Range(0.5f, 1.0f);

		var direction = new Vector2(randomDirectionX,randomDirectionY);
		AddForce(direction * (InitialSpeed + SpeedIncrease * GameManager.Instance.HitCounter));
	}

	public void AddForce(Vector2 force)
		=> Rigidbody.velocity = force;

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

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI") {
            PlayerBounce(collision.transform);
        }
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (transform.position.x > 0) {
			GameManager.Instance.IncreasePlayerScore();
        } else if (transform.position.x < 0) {
            GameManager.Instance.IncreaseComScore();
        }
	}
}
