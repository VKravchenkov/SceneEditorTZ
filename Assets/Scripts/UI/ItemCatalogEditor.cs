using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemCatalogEditor : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;

    private Canvas canvas;
    private RectTransform rectTransform;
    private Transform defoultParent;
    private GameObject prefabInstance;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        defoultParent = rectTransform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.parent = canvas.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject go = Instantiate(prefabInstance);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            go.transform.position = hit.point;
        }
        else
        {
            go.transform.position = Vector3.zero;
        }

        rectTransform.parent = defoultParent;
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void SetName(string text)
    {
        this.text.text = text;
    }

    public void SetCanvas(Canvas canvas)
    {
        this.canvas = canvas;
    }

    public void SetPrefabInstance(GameObject gameObject)
    {
        prefabInstance = gameObject;
    }
}
