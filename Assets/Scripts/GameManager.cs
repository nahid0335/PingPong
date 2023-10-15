using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// GameManager to manage the game
/// </summary>
public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public int playerScore;
	public int comScore;
	public int HitCounter;

	[SerializeField]
	BallMovement ballMovement;

	[SerializeField]
	Text PlayerScoreText;
	[SerializeField]
	Text ComScoreText;

	private void Awake() {
		// singleton
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// inscrease the player score and reset the ball position
	/// </summary>
	public void IncreasePlayerScore()
	{
		++playerScore;
		PlayerScoreText.text = playerScore.ToString();

		ResetBall();
	}

	/// <summary>
	/// increase the AI score and reset the ball position
	/// </summary>
	public void IncreaseComScore()
	{
		++comScore;
		ComScoreText.text = comScore.ToString();

		ResetBall();
	}

	/// <summary>
	/// check if the game is over or reset the ball positon
	/// </summary>
	void ResetBall()
	{
		if (comScore > 4 || playerScore > 4) {
			EndGame();
		}

		ballMovement.Rigidbody.velocity = Vector2.zero;
		ballMovement.transform.position = Vector2.zero;
		HitCounter = 0;
		Invoke("StartBall",2f);
	}

	/// <summary>
	/// start the game by adding force to the ball
	/// </summary>
	void StartBall()
		=> ballMovement.AddStartingForce();

	/// <summary>
	/// go to the end game scene
	/// </summary>
	void EndGame()
		=> SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
