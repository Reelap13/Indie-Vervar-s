using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPointPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _textPanel;

    private void Awake()
    {
        _player.ChangingHPEvent.AddListener(ChangeHP);       
    }

    private void ChangeHP(int value)
    {
        _textPanel.text = "Health point: " + value;
    }
}
