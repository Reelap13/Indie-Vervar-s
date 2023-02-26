using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class DeckSaver : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cards;

    public void SaveDeck(List<GameObject> cards)
    {
        BinaryFormatter bf = new BinaryFormatter();
    }

    /*public List<GameObject> LoadDeck()
    {

    }*/
}

[Serializable]
class SaveDack
{
    private List<string> _deck = new List<string>();

    
}