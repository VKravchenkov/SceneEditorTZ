using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShowCatalog : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private void Awake()
    {
        EventManager.OnShowMagazine += (isShow) => characterController.enabled = !isShow;
    }

    private void OnDisable()
    {
        EventManager.OnShowMagazine -= (isShow) => characterController.enabled = !isShow;
    }
    private void OnTriggerEnter(Collider other)
    {
        characterController.enabled = false;

        EventManager.ShowMagazine(true);
    }
}
