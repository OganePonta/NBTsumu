using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public DragPiece DragPiece { get; private set; }

	private void Awake()
	{
        DragPiece = new DragPiece();
	}

	private void Update()
	{
        if(Input.GetMouseButtonDown(0))
        {
            var ray = GetRaycast();
            DragPiece.OnDragStart(ray);
        } else if(Input.GetMouseButtonUp(0))
        {
            DragPiece.OnDragEnd();
        }
	}

    private RaycastHit2D GetRaycast()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
}

public class DragPiece
{
    public List<PieceController> selectedPieces = new List<PieceController>();

    public void OnDragStart(RaycastHit2D hit)
    {
        if (hit.collider == null) return;
        if (hit.collider.gameObject == null) return;

        var hitGO = hit.collider.gameObject;
        if(hitGO.CompareTag(PieceController.TagName))
        {
            Debug.Log("ドラッグ開始 go: " + hitGO);

            var piece = hitGO.GetComponent<PieceController>();
            OnSelectPiece(piece);
        } else
        {
            // 何もしない
        }
    }

    public void OnDragEnd()
    {
        ResetSelectedPieces();
    }

    private void OnSelectPiece(PieceController piece)
    {
        if (piece == null) return;

        selectedPieces.Add(piece);
        piece.SetColor(Color.black);
    }

    private void ResetSelectedPieces()
    {
        selectedPieces.ForEach(p => p.SetColor(Color.white));
        selectedPieces = new List<PieceController>();
    }
}