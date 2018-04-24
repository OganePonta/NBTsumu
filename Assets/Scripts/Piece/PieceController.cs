using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(PieceView))]
public class PieceController : MonoBehaviour
{
    private PieceView _view;    
    private PieceModel _model;

    public int Score { get { return _model.Score; } }
    public float Scale { get { return _model.Scale; } }

	private void Awake()
	{
        _view = GetComponent<PieceView>();

        Assert.IsNotNull(_view);
	}

    public void SetColor(Color color)
    {
        _view.SetColor(color);
    }
}
