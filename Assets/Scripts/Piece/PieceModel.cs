using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceModel
{
    public int Score { get; private set; }
    public float Scale { get; private set; }

    public PieceModel(int score, float scale)
    {
        Score = score;
        Scale = scale;
    }
}
