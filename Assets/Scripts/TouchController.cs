using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TouchController : MonoBehaviour
{
    [SerializeField]
    private bool _isDrawLineView = false;

    public DragPiece DragPiece { get; private set; }

    private void Awake()
    {
        DragPiece = new DragPiece();

        if (_isDrawLineView)
        {
            DragPiece.LoadLineRenderer(transform);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = GetRaycast();
            DragPiece.OnDragStart(ray);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            DragPiece.OnDragEnd();
        }
        else if (DragPiece.FirstPiece != null)
        {
            var ray = GetRaycast();
            DragPiece.OnDragging(ray);
        }
    }

    private RaycastHit2D GetRaycast()
    {
        return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    }
}

public class DragPiece
{
    private SelectedPieceContainer _selectedPieces = new SelectedPieceContainer();

    private LineRenderer _lineRenderer;

    public PieceController FirstPiece { get { return _selectedPieces.FirstPiece; } }

    public void OnDragStart(RaycastHit2D ray)
    {
        GetPiece(ray, OnSelectPiece);
    }

    public void OnDragging(RaycastHit2D ray)
    {
        GetPiece(ray, OnSelectPiece);
    }

    public void OnDragEnd()
    {
        StageController.I.OnPieceDestroyed(_selectedPieces.Pieces.Count);
        
        if(_selectedPieces.Pieces.Count >= 3)
        {
            _selectedPieces.Pieces.ForEach(p => GameObject.Destroy(p.gameObject));
        }

        ResetSelectedPieces();
        ResetDebugLine();
    }

    public void LoadLineRenderer(Transform parent)
    {
        var go = new GameObject("LineView", typeof(LineRenderer));
        go.transform.parent = parent;
        _lineRenderer = go.GetComponent<LineRenderer>();
        ResetDebugLine();
    }

    private void OnSelectPiece(PieceController piece)
    {
        if (piece == null) return;
        if (!_selectedPieces.CheckIsCorrectPiece(piece)) return;
        if (piece == _selectedPieces.LastPiece) return;

        _selectedPieces.Add(piece);
        piece.SetColor(Color.black);

        if (_lineRenderer != null)
        {
            var positions = _selectedPieces.Pieces.Select(p => p.transform.localPosition).ToArray();
            _lineRenderer.positionCount = positions.Length;
            for (int i = 0; i < positions.Length; i++)
            {
                _lineRenderer.SetPosition(i, positions[i]);
            }
        }
    }

    private void ResetSelectedPieces()
    {
        _selectedPieces.Pieces.ForEach(p => p.SetColor(Color.white));
        _selectedPieces.Reset();
    }

    private void GetPiece(RaycastHit2D ray, Action<PieceController> resfunc)
    {
        if (ray.collider == null) return;
        if (ray.collider.gameObject == null) return;

        var hitGO = ray.collider.gameObject;
        if (hitGO.CompareTag(PieceController.TagName))
        {
            var piece = hitGO.GetComponent<PieceController>();
            resfunc(piece);
        }
    }

    private void ResetDebugLine()
    {
        if (_lineRenderer == null) return;

        _lineRenderer.positionCount = 0;
        _lineRenderer.startWidth = 0.4f;
        _lineRenderer.endWidth = 0.4f;
        var material = new Material(Shader.Find("Sprites/Default"));
        _lineRenderer.material = material;
        _lineRenderer.sortingLayerName = "Debug";
    }
}

public class SelectedPieceContainer
{
    public string PieceID { get; private set; }

    public List<PieceController> Pieces { get; private set; }
    public PieceController FirstPiece
    {
        get
        {
            if (Pieces.Count == 0) return null;
            return Pieces[0];
        }
    }
    public PieceController LastPiece
    {
        get
        {
            if (Pieces.Count == 0) return null;
            return Pieces[Pieces.Count - 1];
        }
    }

    public SelectedPieceContainer()
    {
        Reset();
    }

    public void Add(PieceController piece)
    {
        PieceID = piece.gameObject.name;

        Pieces.Add(piece);
    }

    public void Reset()
    {
        if (Pieces == null) Pieces = new List<PieceController>();

        PieceID = "";
        Pieces.Clear();
    }

    public bool CheckIsCorrectPiece(PieceController piece)
    {
        if (Pieces.Count == 0) return true;
        if (string.IsNullOrEmpty(PieceID)) return true;

        return piece.gameObject.name == PieceID;
    }
}