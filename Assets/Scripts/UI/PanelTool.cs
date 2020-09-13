using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelTool : MonoBehaviour
{
    [SerializeField] private Button buttonMove;
    [SerializeField] private Button buttonRotation;
    [SerializeField] private Button buttonScale;

    [SerializeField] private GameObject selectedIndicator;

    private SelectedMode selectedModeThis;
    public SelectedMode SelectedModeThis
    {
        get { return selectedModeThis; }
        private set
        {
            selectedModeThis = value;

            EventManager.SelectedMode(selectedModeThis);
        }
    }

    private void Awake()
    {
        buttonMove.onClick.AddListener(OnClickButtonMove);
        buttonRotation.onClick.AddListener(OnClickButtonRotation);
        buttonScale.onClick.AddListener(OnClickButtonScale);
    }

    private void OnClickButtonScale()
    {
        SelectedModeThis = SelectedMode.Scale;
    }

    private void OnClickButtonRotation()
    {
        SelectedModeThis = SelectedMode.Rotation;
    }

    private void OnClickButtonMove()
    {
        SelectedModeThis = SelectedMode.Move;
    }
}

public enum SelectedMode
{
    Move = 0,
    Rotation = 1,
    Scale = 2
}
