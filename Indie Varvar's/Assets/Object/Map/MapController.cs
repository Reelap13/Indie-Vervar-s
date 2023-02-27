using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapController : Singleton<MapController>
{
    [SerializeField] private MapSaver _saver;
    [SerializeField] private List<GameObject> _mapGameObject;
    [SerializeField] private GameObject _pathPref;

    private List<List<PointCash>> _mapPoints;
    private Map _mapIds;
    private float _lengthOfPartPath;

    void Awake()
    {
        _lengthOfPartPath = _pathPref.GetComponent<Renderer>().bounds.size.magnitude * 1.1f;
        _mapIds = _saver.LoadMap();
        DecomposeMap();
        DrawPaths();
    }

    private void DecomposeMap()
    {
        _mapPoints = new List<List<PointCash>>();
        for (int i = 0; i < _mapIds.GetMap().Count; ++i)
        {
            _mapPoints.Add(new List<PointCash>());
            for (int j = 0; j < _mapIds.GetMap()[i].Count; ++j)
            {
                _mapPoints[i].Add(null);
            }
        }

        for (int k = 0; k < _mapGameObject.Count; ++k)
        {
            string[] name = _mapGameObject[k].name.Split(" ");
            int i = Int32.Parse(name[1]) - 1;
            int j = Int32.Parse(name[2]) - 1;

            PointCash pointCash = new PointCash(_mapGameObject[k], _mapIds.GetMap()[i][j]);
            _mapGameObject[k].GetComponent<PointPP>().PointCash = pointCash;
            Debug.Log(i + " " + j);
            _mapPoints[i][j] = pointCash;
        }
    }

    private void DrawPaths()
    {
        for (int i = 0; i < _mapIds.GetMap().Count - 1; ++i)
        {
            foreach (PointCash pointCash in _mapPoints[i])
            {
                foreach(Node node in pointCash.Node.GetUpperNodes())
                {
                    DrawPath(pointCash, FindPointCash(node, i + 1));
                }
            }
        }
    }
    private void DrawPath(PointCash first, PointCash second)
    {
        float pathLength = (second.Transform.position - first.Transform.position).magnitude;
        float index = (int)(pathLength / _lengthOfPartPath);
        for (int i = 0; i < index; ++i)
        {
            GameObject path = Instantiate(_pathPref) as GameObject;
            path.transform.position = first.Transform.position + (second.Transform.position - first.Transform.position) * (i + 1) / index;
            path.transform.LookAt(second.Transform);
            path.transform.Rotate(_pathPref.transform.rotation.eulerAngles);
            path.transform.position = new Vector3(path.transform.position.x, 0.1f, path.transform.position.z);
        }
    }

    private PointCash FindPointCash(Node node, int indexOfLine)
    {
        for (int i = 0; i < _mapPoints[indexOfLine].Count; ++i)
        {
            if (_mapPoints[indexOfLine][i].Node.Equals(node))
            {
                return _mapPoints[indexOfLine][i];
            }
        }
        return null;
    }

    public PointCash GetFirstPointer()
    {
        return _mapPoints[0][0];
    }

    public bool IsCanMove(PointCash first, PointCash second)
    {
        foreach (Node node in first.Node.GetUpperNodes())
        {
            if (node.Equals(second.Node))
                return true;
        }
        return false;
    }
}

public class PointCash
{
    public GameObject PointObject;
    public Transform Transform;
    public Node Node;

    public PointCash(GameObject point, Node node)
    {
        PointObject = point;
        Transform = point.GetComponent<Transform>();
        Node = node;
    }
}