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
            _pausePanel.SetActive(true);
    }

    public void HidePausePanel()
    {
        _pausePanel.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
