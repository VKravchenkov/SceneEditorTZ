using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedManager : MonoBehaviour
{
    [SerializeField] private GameObject selectedIndicator;
    [SerializeField] private GameObject selectedObject;

    private void Update()
    {
        ClickSelected();
    }

    private void ClickSelected()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<SelectableObject>() != null)
                {
                    SelectedObject(hit.transform.gameObject);
                }
            }
        }
    }

    private void SelectedObject(GameObject gameObject)
    {
        selectedObject = gameObject;
        selectedIndicator.transform.parent = selectedObject.transform;
        selectedIndicator.transform.position = selectedObject.transform.position;
        selectedIndicator.transform.rotation = Quaternion.identity;
    }
}
