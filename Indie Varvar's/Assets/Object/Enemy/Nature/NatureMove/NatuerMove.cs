using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NatuerMove : MonoBehaviour
{
    [SerializeField] string _description;
    public string Description
    {
        get { return _description; }
    }
    public abstract void DoMove();
}
