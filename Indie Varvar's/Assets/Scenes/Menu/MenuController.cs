using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MapSaver _map;
    [SerializeField] private StartDeck _deck;
    [SerializeField] private PlayerSaver _player;
    [SerializeField] private FigurSaver _figur;
    public void StartNewGame()
    {
        _map.CreateNewMap();
        _deck.SaveStartDeck();
        _player.SetStartHP();
        _figur.SetStartValue();
        LoadScene(1);
    }

    public void LoadScene(int numberOfScene)
    {
        SceneManager.LoadScene(numberOfScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
