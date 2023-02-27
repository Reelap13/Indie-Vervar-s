using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPP : MonoBehaviour
{
    public PointCash PointCash;
    private void OnMouseDown()
    {
        if (!FigurController.Instance.Figur.IsFight)
        {
            if (MapController.Instance.IsCanMove(FigurController.Instance.Figur.GetPointCash(), PointCash))
            {
                FigurController.Instance.Move(PointCash);
            }
        }
    }



}
