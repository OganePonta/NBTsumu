using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private Transform _bornPointOrigin;

    [SerializeField]
    private float _bornPosRadiusX = 7f;

    [SerializeField]
    private float _bornPosRadiusY = 2f;

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
        var randomizeBuffX = Random.Range(-_bornPosRadiusX, _bornPosRadiusX);
        var randomizeBuffY = Random.Range(-_bornPosRadiusY, _bornPosRadiusY);
        startPos.x += randomizeBuffX;
        startPos.y += randomizeBuffY;

        piece.transform.localPosition = startPos;
    }
}
