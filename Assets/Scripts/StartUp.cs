using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("PingPong");
    }
}
