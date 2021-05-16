using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    // Start is called before the first frame update


    public void Game_Start()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;

    }

    public void Game_Exit()
    {
        Application.Quit();
    }
}
