using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private Transform _bornPointOrigin;

    [SerializeField]
    private float _bornPosRadius = 1f;

	private void Start()
	{
        StartStage();
	}

	public void StartStage()
    {
        StartCoroutine(PieceManager.I.CreatePieceLoopCoroutine(transform, 40, OnCreatePiece));
    }

    private void OnCreatePiece(PieceController piece)
    {
        var startPos = _bornPointOrigin.localPosition;
        var randomizeBuffX = Random.Range(-_bornPosRadius, _bornPosRadius);
        startPos.x += randomizeBuffX;

        piece.transform.localPosition = startPos;
    }
}
