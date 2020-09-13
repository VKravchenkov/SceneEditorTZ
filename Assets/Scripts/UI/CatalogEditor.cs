using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalogEditor : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabObjects;
    [SerializeField] private GameObject Content;
    [SerializeField] private GameObject prefabItem;

    [SerializeField] private Canvas canvas;

    private void Start()
    {
        InitItems();
    }

    private void InitItems()
    {
        foreach (GameObject item in prefabObjects)
        {
            GameObject go = Instantiate(prefabItem, Content.transform);
            go.GetComponent<ItemCatalogEditor>().SetName(item.GetComponent<SelectableObject>().NameObject);
            go.GetComponent<ItemCatalogEditor>().SetCanvas(canvas);
            go.GetComponent<ItemCatalogEditor>().SetPrefabInstance(item);
            go.GetComponent<ItemCatalogEditor>().SetIcon(item.GetComponent<SelectableObject>().Icon);
        }
    }
}
