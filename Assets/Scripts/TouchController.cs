using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public DragPieceController DragPiece { get; private set; }

	private void Awake()
	{
        DragPiece = new DragPieceController();
	}

	private void Update()
	{
        if(Input.GetMouseButtonDown(0))
        {
            DragPiece.OnDragStart();
        }
	}
}

public class DragPieceController
{
    public void OnDragStart()
    {
        Debug.Log("ドラッグ開始");
    }
}