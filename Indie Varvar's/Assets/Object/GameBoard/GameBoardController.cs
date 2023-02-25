using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoardController : MonoBehaviour
{
    private List<Field> _fieldBoard = new List<Field>();

    private Transform _tr;

    private void Awake()
    {
        _tr = GetComponent<Transform>();

    }

    public void GenerateBoard()
    {
        
    }

    public Field GetField(int index)
    {
        if (index >= _fieldBoard.Count)
            index = _fieldBoard.Count - 1;

        return _fieldBoard[index];
    }

    public void RemoveField()
    {
        StartCoroutine(RemoveFieldAnimation(1));
    }
    public void RemoveField(int n)
    {
        StartCoroutine(RemoveFieldAnimation(n));
    }

    private IEnumerator RemoveFieldAnimation(int n)
    {
        for (int i = 0; i < n; ++i)
        {
            _fieldBoard[0].Remove();

            yield return new WaitForSeconds(1);
        }

        _fieldBoard.RemoveRange(0, n);




    }
}
