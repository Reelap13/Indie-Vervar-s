using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameBoardController : MonoBehaviour
{
    public static UnityEvent<int> RemovingFirsFields = new UnityEvent<int>();

    [SerializeField] private GameObject _startFieldPref;
    [SerializeField] private List<GameObject> _fieldPrefList;
    [SerializeField] private GameObject _figurePref;
    [SerializeField] private int _numberOfElement;
    
    
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
        { 
            FieldCash fieldCash = CreateFieldCash(_startFieldPref);
            fieldCash.Transform.position = _transform.position;
            _fieldBoard.Add(fieldCash);
        }
        for (int i = 1; i < _numberOfElement; ++i)
        {
            FieldCash fieldCash = CreateFieldCash(_fieldPrefList[Random.Range(0, _fieldPrefList.Count)]);
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

    public void Move(int x)
    {
        if (_figure.IndexOfField + x >= _numberOfElement)
            x = _numberOfElement - _figure.IndexOfField - 1;
        if (_figure.IndexOfField + x < 0)
            x = -_figure.IndexOfField;
        if (x == 0)
            return;
        

        int index = x + _figure.IndexOfField;
        Debug.Log(index);
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