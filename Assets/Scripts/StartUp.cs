using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// initail scene in the game
/// </summary>
public class StartUp : MonoBehaviour
{
	/// <summary>
	/// start the in game scene
	/// </summary>
	public void StartGame()
		=> SceneManager.LoadScene("PingPong");
}
