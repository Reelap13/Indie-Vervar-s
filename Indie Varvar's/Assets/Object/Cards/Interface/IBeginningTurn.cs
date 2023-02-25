using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

 interface IBeginningTurn 
{
    public void StartBeggingAction();
    public void EndBegginingAction();
}

interface IFinishingTurn
{
    public void StartFinishingAction();
    public void EndFinishingAction();
}