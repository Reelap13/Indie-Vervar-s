using UnityEngine;

public class FigurController : Singleton<FigurController>
{
    [SerializeField] private FigurSaver _saver;

    private FigurSave figur;
    private Transform _transform;
    private void Start()
    {
        figur = _saver.LoadFigur();
        _transform = GetComponent<Transform>();
        _transform.position = figur.GetPointCash().Transform.position;
    }

    public void Move(PointCash pointCash)
    {
        figur.SetPointCash(pointCash);
        figur.IsFight = true;
        _transform.position = pointCash.Transform.position;
    }

    public FigurSave Figur
    {
        get
        {
            return figur;
        }
    }
}
