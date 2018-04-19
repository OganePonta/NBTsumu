using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private CoinModel _model;

    public int Score { get { return _model.Score; } }
    public float Scale { get { return _model.Scale; } }
}
