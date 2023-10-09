using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
	TMP_Text Score;
	[SerializeField]
	TMP_Text Status;

	// public GameManager gameManager;

	// Start is called before the first frame update
	void Start()
    {
        var gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager.playerScore > gameManager.comScore) {
            Status.text = "You Win";
        } else {
			Status.text = "You Lose";
		}

        Score.text = $"{gameManager.playerScore} : {gameManager.comScore}";
    }
}
