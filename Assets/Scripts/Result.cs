using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
	TMP_Text Score;
	[SerializeField]
	TMP_Text Status;

	void Start()
    {
        if (GameManager.Instance.playerScore > GameManager.Instance.comScore) {
            Status.text = "You Win";
        } else {
			Status.text = "You Lose";
		}

        Score.text = $"{GameManager.Instance.playerScore} : {GameManager.Instance.comScore}";
    }
}
