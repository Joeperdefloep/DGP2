using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] Image image;

    public event Action<Item> OnRightClickEvent;

    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;

            if(_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right) {
            if (Item != null && OnRightClickEvent != null)
                OnRightClickEvent(Item);
        }

    }

    

    private void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    Vector2 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = image.transform.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.transform.position = originalPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        image.transform.position = Input.mousePosition;
    }
}