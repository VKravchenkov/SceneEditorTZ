using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCatalog : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private Text textCost;
    [SerializeField] private RectTransform parentRectItem;
    [SerializeField] private Canvas canvas;

    public InventoryItemBase InventoryItem { get; private set; }
    public int Cost { get; private set; }

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        rectTransform.parent = canvas.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        if (rectTransform.parent == canvas.transform)
        {
            SetParent(parentRectItem);
        }

        EventManager.UpdateBasket();
    }

    public void SetParent(RectTransform rectTransform)
    {
        this.rectTransform.parent = rectTransform;
        this.rectTransform.localPosition = Vector3.zero;
    }

    public void SetParentDefoult()
    {
        SetParent(parentRectItem);
    }

    public void SetInventoryItemBase(InventoryItemBase inventoryItemBase)
    {
        InventoryItem = inventoryItemBase;
        SetImage(inventoryItemBase.Image);
    }

    public void SetCost(int cost)
    {
        Cost = cost;
        textCost.text = cost.ToString();
    }

    private void SetImage(Sprite sprite)
    {
        icon.sprite = sprite;
    }
}
