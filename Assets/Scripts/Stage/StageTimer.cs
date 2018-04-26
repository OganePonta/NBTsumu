using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StageTimer : MonoBehaviour
{
    public enum TimerMode
    {
        Timer99 = 99,
        Timer50 = 50,
        Timer30 = 30,
    }

    [SerializeField]
    private Text _timerText;

    private Action _onEndTimer;

    public int Timer { get; private set; }
    public bool IsRunning { get; private set; }

	private void Awake()
	{
        IsRunning = false;
	}

    public void Setup(TimerMode mode, Action onEndTimer)
    {
        Timer = (int)mode;
        SetTimerText(Timer);
        _onEndTimer = onEndTimer;
    }

    public void Invoke()
    {
        IsRunning = true;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        var span = new WaitForSeconds(1f);
        while(IsRunning)
        {
            yield return span;
            Timer--;
            SetTimerText(Timer);
            if (Timer <= 0)
            {
                Timer = 0;
                _onEndTimer();
                IsRunning = false;
            }
        }
    }

    private void SetTimerText(int time)
    {
        if (_timerText == null) return;
        _timerText.text = time.ToString();
    }
}
