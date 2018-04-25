using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StageController : SingletonMonoBehaviour<StageController>
{
    [SerializeField]
    private Transform _bornPointOrigin;

    [SerializeField]
    private float _bornPosRadiusX = 7f;

    [SerializeField]
    private float _bornPosRadiusY = 12f;

    private static readonly int DefaultBornPiecesCount = 45;

    private void Start()
    {
        StartStage();
    }

    public void StartStage()
    {
        CallCreateLoopCoroutine(transform, DefaultBornPiecesCount, OnCreatePiece);
    }

    public void OnPieceDestroyed(int count)
    {
        CallCreateLoopCoroutine(transform, count, OnCreatePiece);
    }

    private void CallCreateLoopCoroutine(Transform parent, int count, Action<PieceController> onCreate)
    {
        StartCoroutine(PieceManager.I.CreatePieceLoopCoroutine(parent, count, onCreate));
    }

    private void OnCreatePiece(PieceController piece)
    {
        var startPos = _bornPointOrigin.localPosition;
        var randomizeBuffX = UnityEngine.Random.Range(-_bornPosRadiusX, _bornPosRadiusX);
        var randomizeBuffY = UnityEngine.Random.Range(-_bornPosRadiusY, _bornPosRadiusY * 3);
        startPos.x += randomizeBuffX;
        startPos.y += randomizeBuffY;

        piece.transform.localPosition = startPos;
    }
}
