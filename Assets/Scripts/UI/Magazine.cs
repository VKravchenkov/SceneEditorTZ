using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magazine : MonoBehaviour
{

    [SerializeField] private Button buttonBuy;
    [SerializeField] private Button buttonExit;

    private void Awake()
    {
        buttonBuy.onClick.AddListener(OnClickButtonBuy);
        buttonExit.onClick.AddListener(OnClickButtonExit);

        EventManager.OnShowMagazine += Show;
    }

    private void Start()
    {
        Show(false);
    }

    private void OnClickButtonExit()
    {
        EventManager.ShowMagazine(false);

    }

    private void OnClickButtonBuy()
    {
        EventManager.TryBuy();
    }

    private void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }
}
