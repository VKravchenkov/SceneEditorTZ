using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event Action<bool> OnShowMagazine;
    public static event Action<bool> OnShowModeGame;
    public static event Action<bool> OnShopModeEditor;

    public static event Action<bool> OnShowPlayer;
    public static event Action<bool> OnShowInventoryPanel;
    public static event Action<bool> OnShowBarsPanel;

    public static event Action OnUpdateBasket;
    public static event Action OnTryBuy;

    public static event Action<SelectedMode> OnSelectedMode;

    public static event Action<bool> OnActiveCameraController;

    public static void ShowMagazine(bool isShow) => OnShowMagazine?.Invoke(isShow);
    public static void ShowModeGame(bool isShow) => OnShowModeGame?.Invoke(isShow);
    public static void ShowModeEditor(bool isShow) => OnShopModeEditor?.Invoke(isShow);
    public static void ShowPlayer(bool isShow) => OnShowPlayer?.Invoke(isShow);
    public static void ShowInventoryPanel(bool isShow) => OnShowInventoryPanel?.Invoke(isShow);
    public static void ShowBarsPanel(bool isShow) => OnShowBarsPanel?.Invoke(isShow);
    public static void UpdateBasket() => OnUpdateBasket?.Invoke();
    public static void TryBuy() => OnTryBuy?.Invoke();
    public static void SelectedMode(SelectedMode selectedMode) => OnSelectedMode?.Invoke(selectedMode);
    public static void ActiveCameraController(bool isActive) => OnActiveCameraController?.Invoke(isActive);
}
