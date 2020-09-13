using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeGame : MonoBehaviour
{
    [SerializeField] private Button buttonModeEditor;
    [SerializeField] private Button buttonModeShop;

    private void Awake()
    {
        buttonModeEditor.onClick.AddListener(OnClickButtonModeEditor);
        buttonModeShop.onClick.AddListener(OnClickButtonModeShop);
    }

    private void OnClickButtonModeShop()
    {
        EventManager.ShowPlayer(true);
        EventManager.ShowInventoryPanel(true);
        EventManager.ShowBarsPanel(true);

        EventManager.ShowModeGame(true);

        gameObject.SetActive(false);

    }

    private void OnClickButtonModeEditor()
    {
        EventManager.ShowModeEditor(true);

        EventManager.ActiveCameraController(true);

        gameObject.SetActive(false);
    }
}
