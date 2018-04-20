﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceManager : SingletonMonoBehaviour<PieceManager>
{
    [SerializeField]
    private Transform _bornPointOrigin;

    private List<PieceController> _bornPieceList = new List<PieceController>();

    private const float CreateLoopSpan = 0.1f;

    public void CreateAtRandom(Transform parent, Action<PieceController> onCreate)
    {
        var index = UnityEngine.Random.Range(0, _bornPieceList.Count - 1);
        var prefab = _bornPieceList[index];
        PieceController piece = Instantiate(prefab, parent);

        onCreate(piece);
    }

    public IEnumerator CreatePieceLoopCoroutine(Transform parent, int count, Action<PieceController> onCreate)
    {
        var wait = new WaitForSeconds(CreateLoopSpan);
        for (int i = 0; i < count; i++)
        {
            CreateAtRandom(parent, onCreate);

            yield return wait;
        }
    }

    private void DebugLoadPrefab()
    {
        _bornPieceList = new List<PieceController>();

        _bornPieceList.Add(Resources.Load("Prefabs/Piece/face_001") as PieceController);
        _bornPieceList.Add(Resources.Load("Prefabs/Piece/face_002") as PieceController);
        _bornPieceList.Add(Resources.Load("Prefabs/Piece/face_003") as PieceController);
        _bornPieceList.Add(Resources.Load("Prefabs/Piece/face_004") as PieceController);
        _bornPieceList.Add(Resources.Load("Prefabs/Piece/face_005") as PieceController);
    }
}
