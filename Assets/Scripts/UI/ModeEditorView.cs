using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeEditorView : MonoBehaviour
{
    private void Awake()
    {
        EventManager.OnShopModeEditor += (isShow) => gameObject.SetActive(isShow);
    }

    private void OnDisable()
    {
        EventManager.OnShopModeEditor -= (isShow) => gameObject.SetActive(isShow);
    }

}
