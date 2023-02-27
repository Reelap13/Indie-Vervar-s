using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadScene(int numberOfScene)
    {
        SceneManager.LoadScene(numberOfScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
