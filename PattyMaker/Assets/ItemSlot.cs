using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public GameObject popUp; // Reference to your pop-up input field GameObject
    private bool hasItem = false;

    void Start()
    {
        // Initially, deactivate the pop-up
        if (popUp != null)
            popUp.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            // Set the anchored position of the dragged item to match this slot
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            // Disable any drag-related scripts (if applicable)
            DragDrop dragScript = eventData.pointerDrag.GetComponent<DragDrop>();
            if (dragScript != null)
                dragScript.enabled = false;

            // Show the PopUp (if available)
            if (popUp != null)
                popUp.SetActive(true);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");

        // Show the PopUp when the slot is clicked (if available)
        if (popUp != null)
            popUp.SetActive(true);
    }
}
