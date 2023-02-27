using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MapSaver : MonoBehaviour
{
    private const string PATH = "MapSave";
    public void CreateNewMap()
    {
        List<List<Node>> map = new List<List<Node>>();

        map.Add(CreateNewLineOfNode(1));
        map.Add(CreateNewLineOfNode(2));
        map.Add(CreateNewLineOfNode(3));
        map.Add(CreateNewLineOfNode(2));
        map.Add(CreateNewLineOfNode(3));
        map.Add(CreateNewLineOfNode(3));
        map.Add(CreateNewLineOfNode(1));

        for (int i = 0; i < map.Count - 1; ++i)
        {
            CreateInstance(map[i], map[i + 1]);
        }

        SetIdForLine(map[2], 2);
        SetIdForLine(map[3], 10);
        SetIdForLine(map[4], 2);
        SetIdForLine(map[5], 3);
        SetIdForLine(map[6], 4);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Create);

        Map mapp = new Map();
        mapp.SetMap(map);

        bf.Serialize(fs, mapp);

        fs.Close();

    }

    public Map LoadMap()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(PATH, FileMode.Open);

        Map map = (Map)bf.Deserialize(fs);

        fs.Close();

        return map;
    }

    private List<Node> CreateNewLineOfNode(int n)
    {
        List<Node> line = new List<Node>();
        for (int i = 0; i < n; ++i)
        {
            Node newNode = new Node();
            line.Add(newNode);
        }

        return line;
    }

    private void CreateInstance(List<Node> firstLine, List<Node> secondLine)
    {
        if (firstLine.Count == 1)
        {
            foreach (Node node in secondLine)
            {
                firstLine[0].AddUpperNode(node);
            }
        }
        else if (secondLine.Count == 1)
        {
            foreach (Node node in firstLine)
            {
                node.AddUpperNode(secondLine[0]);
            }
        }
        else if (firstLine.Count == 2 && secondLine.Count == 3)
        {
            firstLine[0].AddUpperNode(secondLine[0]);
            firstLine[1].AddUpperNode(secondLine[2]);

            bool t = false;
            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[0].AddUpperNode(secondLine[1]);
            }

            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[1].AddUpperNode(secondLine[1]);
            }
            if (!t)
            {
                if (UnityEngine.Random.Range(0, 2) < 1)
                    firstLine[0].AddUpperNode(secondLine[1]);
                else
                    firstLine[1].AddUpperNode(secondLine[1]);
            }
        }
        else if (firstLine.Count == 3 && secondLine.Count == 2)
        {
            firstLine[0].AddUpperNode(secondLine[0]);
            firstLine[2].AddUpperNode(secondLine[1]);

            bool t = false;
            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[1].AddUpperNode(secondLine[0]);
            }

            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[1].AddUpperNode(secondLine[1]);
            }
            if (!t)
            {
                if (UnityEngine.Random.Range(0, 2) < 1)
                    firstLine[1].AddUpperNode(secondLine[0]);
                else
                    firstLine[1].AddUpperNode(secondLine[1]);
            }
        }
        else if (firstLine.Count == 3 && secondLine.Count == 3)
        {
            firstLine[0].AddUpperNode(secondLine[0]);
            firstLine[2].AddUpperNode(secondLine[2]);

            bool t = false;
            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                firstLine[0].AddUpperNode(secondLine[1]);
            }
            else if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[1].AddUpperNode(secondLine[0]);
            }

            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[1].AddUpperNode(secondLine[1]);
            }

            if (UnityEngine.Random.Range(0, 2) < 1)
            {
                firstLine[1].AddUpperNode(secondLine[2]);
            }
            else if (UnityEngine.Random.Range(0, 2) < 1)
            {
                t = true;
                firstLine[2].AddUpperNode(secondLine[1]);
            }

            if (!t)
            {
                firstLine[1].AddUpperNode(secondLine[1]);
            }
        }
    }

    private void SetIdForLine(List<Node> line, int id)
    {
        foreach (Node node in line)
        {
            node.Id = id;

        }
    }
}

[Serializable]
public class Map
{
    private List<List<Node>> _map = new List<List<Node>>();

    public void SetMap(List<List<Node>> map)
    {
        _map = map;
    }

    public List<List<Node>> GetMap()
    {
        return _map;
    }
}

[Serializable]
public class Node
{
    private List<Node> _upperNodes = new List<Node>();
    private int _id;
    private bool _isPassed;
    private bool _isStayingPlayer;

    public Node(int id = 1)
    {
        _id = id;
        _isPassed = false;
        _isStayingPlayer = false;
    }

    public void AddUpperNode(Node node)
    {
        _upperNodes.Add(node);
    }

    public List<Node> GetUpperNodes()
    {
        return _upperNodes;
    }

    public int Id
    {
        set
        {
            _id = value;
        }
        get
        {
            return _id;
        }
    }
}