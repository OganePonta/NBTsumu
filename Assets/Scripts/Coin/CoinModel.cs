using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
