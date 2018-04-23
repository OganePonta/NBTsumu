using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
	private void Start()
	{
        StartStage();
	}

	public void StartStage()
    {
        // 20個生成しておく
        StartCoroutine(PieceManager.I.CreatePieceLoopCoroutine(transform, 20, piece => { }));
    }
}
