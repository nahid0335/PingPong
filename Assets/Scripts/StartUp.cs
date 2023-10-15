using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
	public void StartGame()
		=> SceneManager.LoadScene("PingPong");
}
