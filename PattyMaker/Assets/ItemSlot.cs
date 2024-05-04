using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public GameObject popUp; 
    private bool hasItem = false;

    void Start()
    {
   
        if (popUp != null)
            popUp.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            DragDrop dragScript = eventData.pointerDrag.GetComponent<DragDrop>();
            if (dragScript != null)
                dragScript.enabled = false;

            if (popUp != null)
                popUp.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");

        if (popUp != null)
            popUp.SetActive(true);
    }
}
