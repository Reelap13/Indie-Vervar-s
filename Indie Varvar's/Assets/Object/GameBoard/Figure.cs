using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure : MonoBehaviour
{
    private int _indexOfField;
    private FieldCash _currentFieldCash;
    private Vector3 indent = new Vector3(0, 0, 0);
    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        GameBoardController.RemovingFirsFields.AddListener(ReduceIndex);
    }

    private void ReduceIndex(int n)
    {
        _indexOfField -= n;
    }

    public void MoveToField(FieldCash fieldCash, int numberOfField)
    {
        if (_currentFieldCash.Field != null)
            DisactivateField(_currentFieldCash);
        ActivateField(fieldCash);

        _currentFieldCash = fieldCash;
        _transform.parent = fieldCash.Transform;
        _transform.position = fieldCash.Transform.position + indent;
        _indexOfField = numberOfField;
    }

    private void ActivateField(FieldCash fieldCash)
    {
        if (fieldCash.Field is IActiveField)
        {
            ((IActiveField)fieldCash.Field).Activate();
        }
    }
    private void DisactivateField(FieldCash fieldCash)
    {
        if (fieldCash.Field is IActiveField)
        {
            ((IActiveField)fieldCash.Field).Disactivate();
        }
    }

    public int IndexOfField
    {
        get
        {
            return _indexOfField;
        }
    }

    public FieldCash CurrentFieldCash
    {
        get
        {
            return _currentFieldCash;
        }
    }
}
