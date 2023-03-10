using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _textPanel;

    private void Awake()
    {
        _player.ChangingManaEvent.AddListener(ChangeMana);
    }

    private void ChangeMana(int value)
    {
        _textPanel.text = "Mana: " + value;
    }
}
