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
        }
	}

    private RaycastHit2D GetRaycast()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
}

public class DragPiece
{
    public void OnDragStart(RaycastHit2D hit)
    {
        if (hit.collider == null) return;
        if (hit.collider.gameObject == null) return;

        var hitGO = hit.collider.gameObject;
        if(hitGO.CompareTag("Piece"))
        {
            Debug.Log("ドラッグ開始 go: " + hitGO);
        } else
        {
            // 何もしない
        }
    }
}