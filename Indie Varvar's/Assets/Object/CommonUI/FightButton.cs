using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightButton : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private void Update()
    {
        button.SetActive(FigurController.Instance.Figur.IsFight);   
    }

    public void LoadSceen(int n)
    {
        SceneManager.LoadScene(n);
    }
}
