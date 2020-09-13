using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagazine : MonoBehaviour
{
    [SerializeField] private ItemCatalog[] itemCatalogs;
    [SerializeField] private List<GameObject> inventoryItemBasesPrefab;

    private void Awake()
    {
        InitCatalogs();
    }

    private void InitCatalogs()
    {
        for (int i = 0; i < inventoryItemBasesPrefab.Count; i++)
        {
            GameObject goItem = Instantiate(inventoryItemBasesPrefab[i]);

            goItem.SetActive(false);

            itemCatalogs[i].SetInventoryItemBase(goItem.GetComponent<InventoryItemBase>());
            itemCatalogs[i].SetCost(UnityEngine.Random.Range(0, 100));
        }
    }
}
