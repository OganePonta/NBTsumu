using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(PieceView))]
public class PieceController : MonoBehaviour
{
    private PieceView _view;    
    private PieceModel _model;

    public static readonly string TagName = "Piece";

    private static readonly Color SelectedColor = new Color(1f, 1f, 1f, 0.6f);

    public int Score { get { return _model.Score; } }
    public float Scale { get { return _model.Scale; } }

	private void Awake()
	{
        _view = GetComponent<PieceView>();

        Assert.IsNotNull(_view);
        Assert.IsTrue(gameObject.CompareTag(TagName));
	}

    public void SetSelectedColor()
    {
        SetColor(SelectedColor);
    }

    public void SetDefaultColor()
    {
        SetColor(Color.white);
    }

    private void SetColor(Color color)
    {
        _view.SetColor(color);
    }
}
