using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject InventaryPanel;
    [SerializeField] private GameObject BarsPanel;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject cameraPlayer;

    private void Awake()
    {
        EventManager.OnShowInventoryPanel += (isShow) => InventaryPanel.SetActive(isShow);
        EventManager.OnShowBarsPanel += (isShow) => BarsPanel.SetActive(isShow);
        EventManager.OnActiveCameraController += (isActive) => cameraController.enabled = isActive;
        EventManager.OnShowModeGame += (isActive) => cameraPlayer.SetActive(isActive);
    }

    private void Start()
    {
        EventManager.ShowPlayer(false);
        EventManager.ShowInventoryPanel(false);
        EventManager.ShowBarsPanel(false);
        EventManager.ShowModeEditor(false);

        EventManager.ActiveCameraController(false);
    }

    private void OnDisable()
    {
        EventManager.OnShowInventoryPanel -= (isShow) => InventaryPanel.SetActive(isShow);
        EventManager.OnShowBarsPanel -= (isShow) => BarsPanel.SetActive(isShow);
        EventManager.OnActiveCameraController += (isActive) => cameraController.enabled = isActive;
        EventManager.OnShowModeGame -= (isActive) => cameraPlayer.SetActive(isActive);
    }
}
