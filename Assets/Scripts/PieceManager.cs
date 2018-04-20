using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PieceManager : SingletonMonoBehaviour<PieceManager>
{
    private List<PieceController> _bornPieceList = new List<PieceController>();

    public void CreateAtRandom(Transform parent, Action<PieceController> onCreate)
    {
        var index = UnityEngine.Random.Range(0, _bornPieceList.Count - 1);
        var prefab = _bornPieceList[index];
        PieceController piece = Instantiate(prefab, parent);

        onCreate(piece);
    }
}
