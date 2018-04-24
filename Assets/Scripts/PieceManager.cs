using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;
using System.Linq;

public class PieceManager : SingletonMonoBehaviour<PieceManager>
{
    [SerializeField]
    private bool _isDebugMode = false;

    private List<GameObject> _bornPieceList = new List<GameObject>();

    private const float CreateLoopSpan = 0.05f;

	private void Awake()
	{
        if(_isDebugMode)
        {
            DebugLoadPrefab();
        }
	}

	public void CreateAtRandom(Transform parent, Action<PieceController> onCreate)
    {
        Assert.IsNotNull(_bornPieceList);

        if (_bornPieceList == null) return;
        if (_bornPieceList.Count == 0) return;

        var index = UnityEngine.Random.Range(0, _bornPieceList.Count - 1);
        var prefab = _bornPieceList[index];
        PieceController piece = Instantiate(prefab, parent).GetComponent<PieceController>();

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
        _bornPieceList = new List<GameObject>()
        {
            Resources.Load("Prefabs/Piece/face_001") as GameObject,
            Resources.Load("Prefabs/Piece/face_002") as GameObject,
            Resources.Load("Prefabs/Piece/face_003") as GameObject,
            Resources.Load("Prefabs/Piece/face_004") as GameObject,
            Resources.Load("Prefabs/Piece/face_005") as GameObject,
        };

        _bornPieceList.ForEach(p => Debug.Log("ロード完了ピース -> " + p));
    }
}
