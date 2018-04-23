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
        // 20個生成しておく
        StartCoroutine(PieceManager.I.CreatePieceLoopCoroutine(transform, 20, OnCreatePiece));
    }

    private void OnCreatePiece(PieceController piece)
    {
    }
}
