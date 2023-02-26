using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBoardController : MonoBehaviour
{
    public static UnityEvent<int> RemovingFirsFields = new UnityEvent<int>();

    [SerializeField] private GameObject _fieldPref;
    [SerializeField] private GameObject _figurePref;
    
    
    private List<FieldCash> _fieldBoard = new List<FieldCash>();
    private Vector3 INDENT = new Vector3(0, 0, 10) * 1.5f;

    private Transform _transform;
    private Figure _figure;

    private void Awake()
    {
        _transform = GetComponent<Transform>();

        GenerateBoard();
        CreatePlayerFigure();
    }

    private void GenerateBoard()
    {
        for (int i = 0; i < 10; ++i)
        {
            FieldCash fieldCash = CreateFieldCash(_fieldPref);
            fieldCash.Transform.position = _transform.position + INDENT * i;
            _fieldBoard.Add(fieldCash);
        }
    }

    private FieldCash CreateFieldCash(GameObject fieldPref)
    {
        GameObject newField = Instantiate(fieldPref) as GameObject;
        FieldCash fieldCash = new FieldCash(newField);

        return fieldCash;
    }

    private void CreatePlayerFigure()
    {
        GameObject newFigure = Instantiate(_figurePref) as GameObject;
        _figure = newFigure.GetComponent<Figure>();
        _figure.MoveToField(_fieldBoard[0], 0);
    }

    public void MoveForward()
    {
        int index = _figure.IndexOfField + 1;
        if (index >= _fieldBoard.Count)
            index = _fieldBoard.Count - 1;
        
        _figure.MoveToField(_fieldBoard[index], index);

    }
    public void MoveBack()
    {
        int index = _figure.IndexOfField - 1;
        if (index < 0)
            index = 0;

        _figure.MoveToField(_fieldBoard[index], index);
    }

    public void JumpForward(int n)
    {
        int index = _figure.IndexOfField + n;
        if (index >= _fieldBoard.Count)
            index = _fieldBoard.Count - 1;

        _figure.MoveToField(_fieldBoard[index], index);
    }
    public void JumpBack(int n)
    {
        int index = _figure.IndexOfField - n;
        if (index < 0)
            index = 0;

        _figure.MoveToField(_fieldBoard[index], index);
    }

    public FieldCash GetField(int index)
    {
        if (index >= _fieldBoard.Count)
            index = _fieldBoard.Count - 1;

        return _fieldBoard[index];
    }

    private void RemoveFields(int n = 1)
    {
        StartCoroutine(RemoveFieldAnimation(n));
    }

    private IEnumerator RemoveFieldAnimation(int n)
    {
        RemovingFirsFields.Invoke(n);

        for (int i = 0; i < n; ++i)
        {
            _fieldBoard[0].Field.Remove();

            yield return new WaitForSeconds(0.3f);
        }

        _fieldBoard.RemoveRange(0, n);
        RemovingFirsFields.Invoke(n);
    }
}


public struct FieldCash
{
    public GameObject FieldObject;
    public Transform Transform;
    public Field Field;

    public FieldCash(GameObject field)
    {
        FieldObject = field;
        Transform = field.GetComponent<Transform>();
        Field = field.GetComponent<Field>();
    }
}