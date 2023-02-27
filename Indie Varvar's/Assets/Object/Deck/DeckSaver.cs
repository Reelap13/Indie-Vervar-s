using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DeckSaver : MonoBehaviour
{
    [SerializeField] private List<GameObject> _cards;
    private const string PATH = "SavedDeck";

    public void SaveDeck(List<GameObject> cards)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Create);

        SaveDeck deck = new SaveDeck(cards);

        bf.Serialize(fs, deck);

        fs.Close();

        Debug.Log("Deck was saved");
    }

    public List<GameObject> LoadDeck()
    {
        if (!File.Exists(PATH))
        {
            Debug.Log("File didn't exist");
            return null;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Open);

        SaveDeck deck = (SaveDeck)bf.Deserialize(fs);

        fs.Close();

        Debug.Log("Deck was loaded");
        return GetDeckByNames(deck.GetDeck());
    }

    private List<GameObject> GetDeckByNames(List<string> cardNames)
    {
        List<GameObject> deck = new List<GameObject>();

        foreach(string name in cardNames)
        {
            foreach(GameObject card in _cards)
            {
                if (name.Equals(card.name))
                {
                    deck.Add(card);
                    break;
                }
            }
        }

        return deck;
    }
}

[Serializable]
class SaveDeck
{
    private List<string> _deck;

    public SaveDeck(List<GameObject> deck)
    {
        _deck = new List<string>();
        foreach (GameObject card in deck)
        {
            AddCard(card.name);
        }
    }

    public void AddCard(string card)
    {
        _deck.Add(card);
    }

    public void AddDeck(List<string> deck)
    {
        _deck = deck;
    }
    public List<string> GetDeck()
    {
        return _deck;
    }
}