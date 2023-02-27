using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonUI : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void HidePausePanel()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
