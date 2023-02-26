using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _textPanel;

    private void Awake()
    {
        _player.ChangingShieldEvent.AddListener(ChangeShield);
    }

    private void ChangeShield(int value)
    {
        _textPanel.text = "Shield: " + value;
    }
}

