using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketController : MonoBehaviour
{
    [SerializeField] private RectTransform[] transforms;

    [SerializeField] private Text textAllCost;
    [SerializeField] private Text textAccumulatedMoney;

    [SerializeField] private Inventory inventory;

    public int AllCost { get; private set; }
    public int AccumulatedMoney { get; private set; } = 500;

    private void Awake()
    {
        SetTextAccumulatedMoney();
    }

    private void OnEnable()
    {
        EventManager.OnUpdateBasket += CalculateTotalCost;
        EventManager.OnTryBuy += TryBuy;
    }

    private void OnDisable()
    {
        EventManager.OnUpdateBasket -= CalculateTotalCost;
        EventManager.OnTryBuy -= TryBuy;
    }


    private void CalculateTotalCost()
    {
        AllCost = 0;

        foreach (RectTransform item in transforms)
        {
            if (item.childCount != 0)
            {
                AllCost += item.GetChild(0).GetComponent<ItemCatalog>().Cost;
            }
        }
        SetTextAllCost();
    }

    private void SetTextAllCost()
    {
        textAllCost.text = AllCost.ToString();
    }

    private void SetTextAccumulatedMoney()
    {
        textAccumulatedMoney.text = AccumulatedMoney.ToString();
    }

    private void TryBuy()
    {
        if (AccumulatedMoney - AllCost > 0)
        {
            AccumulatedMoney -= AllCost;
            SetTextAccumulatedMoney();

            foreach (RectTransform item in transforms)
            {
                if (item.childCount != 0)
                {
                    InventoryItemBase itemBase = item.GetChild(0).GetComponent<ItemCatalog>().InventoryItem;

                    inventory.AddItem(itemBase);

                    itemBase.OnPickup();

                    if (itemBase.UseItemAfterPickup)
                    {
                        inventory.UseItem(itemBase);
                    }
                }
            }

        }

        ClearBusket();
    }

    private void ClearBusket()
    {
        AllCost = 0;
        SetTextAllCost();
        foreach (RectTransform item in transforms)
        {
            if (item.childCount != 0)
            {
                Destroy(item.GetChild(0).gameObject);
            }
        }
    }
}