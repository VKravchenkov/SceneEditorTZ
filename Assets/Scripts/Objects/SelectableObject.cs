using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableObject : MonoBehaviour
{
    [SerializeField] private string nameObject;
    [SerializeField] private Sprite icon;

    public string NameObject => nameObject;
    public Sprite Icon => icon;
}
