using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _armorPanel;
    [SerializeField] private TextMeshProUGUI _strengthPanel;
    [SerializeField] private TextMeshProUGUI _speedPanel;

    private void Awake()
    {
        _player.ChangingArrmorEvent.AddListener(ChangeShield);
        _player.ChangingStrenghtEvent.AddListener(ChangeStrengrh);
        _player.ChangingSpeedEvent.AddListener(ChangeSpeed);
        _armorPanel.text = "Armor: " + _player.Arrmor;
        _strengthPanel.text = "Strength: " + _player.Strength;
        _speedPanel.text = "Speed: " + _player.Speed * 100 + "%";
    }

    private void ChangeShield(int value)
    {
        _armorPanel.text = "Armor: " + (_player.Arrmor + value);
    }
    private void ChangeStrengrh(int value)
    {
        _strengthPanel.text = "Strength: " + (_player.Strength + value);
    }
    private void ChangeSpeed(float value)
    {
        _speedPanel.text = "Speed: " + _player.Speed * 100 + "%";
    }
}

