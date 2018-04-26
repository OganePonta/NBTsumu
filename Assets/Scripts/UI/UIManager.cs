using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField]
    private Button _tapToStartButton;

    public void ShowTapToStartModal()
    {
        _tapToStartButton.gameObject.SetActive(true);
    }

    public void SetOnTapToStartCallback(Action<Button> onClick)
    {
        _tapToStartButton.onClick.AddListener(() => onClick(_tapToStartButton));
    }
}
