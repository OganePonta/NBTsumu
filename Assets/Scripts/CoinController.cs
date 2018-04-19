using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinModel _model;

    public int Score { get { return _model.Score; } }
    public float Scale { get { return _model.Scale; } }
}

public class CoinModel
{
    public int Score { get; private set; }
    public float Scale { get; private set; }

    public CoinModel(int score, float scale)
    {
        Score = score;
        Scale = scale;
    }
}
