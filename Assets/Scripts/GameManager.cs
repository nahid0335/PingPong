using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private int playerScore;
	private int comScore;

	[SerializeField]
	public Paddle PlayerPaddle;
	[SerializeField]
	public Paddle comPaddle;
	[SerializeField]
	public Ball Ball;
	[SerializeField]
	public TMP_Text PlayerScoreText;
	[SerializeField]
	public TMP_Text ComScoreText;

	public void IncreasePlayerScore()
	{
		++playerScore;
		PlayerScoreText.text = playerScore.ToString();

		ResetGame();
	}

	public void IncreaseComScore()
	{
		++comScore;
		ComScoreText.text = comScore.ToString();
		
		ResetGame();
	}

	void ResetGame() 
	{
		PlayerPaddle.ResetPosition();
		comPaddle.ResetPosition();
		Ball.ResetPosition();
		Ball.AddStartingForce();
	}
}
