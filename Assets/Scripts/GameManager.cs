using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void IncreasePlayerScore()
	{
		++playerScore;
		PlayerScoreText.text = playerScore.ToString();

		ResetBall();
	}

	public void IncreaseComScore()
	{
		++comScore;
		ComScoreText.text = comScore.ToString();

		ResetBall();
	}

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

	void StartBall()
		=> ballMovement.AddStartingForce();

	void EndGame()
		=> SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
