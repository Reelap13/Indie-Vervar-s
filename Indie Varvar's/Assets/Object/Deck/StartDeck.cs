using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDeck : MonoBehaviour
{
    [SerializeField] private List<GameObject> _startCardPrefs;
    [SerializeField] private DeckSaver saver;

    public void SaveStartDeck()
    {
        saver.SaveDeck(_startCardPrefs);
    }
}
