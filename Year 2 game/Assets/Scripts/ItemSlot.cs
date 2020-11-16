using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : BaseItemSlot, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private bool isDragging;
    private Color dragColor = new Color(1, 1, 1, 0.5f);

    public override bool CanAddStack(Item item, int amount = 1)
    {
        return base.CanAddStack(item, amount) && Amount + amount <= item.MaximumStacks;
    }

    public bool CanReceiveItem(Item item) // should be public override
    {
        return true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;

        if (Item != null)
            image.color = dragColor;

        if (OnBeginDragEvent != null)
            OnBeginDragEvent(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        if (Item != null)
            image.color = normalColor;

        if (OnEndDragEvent != null)
            OnEndDragEvent(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
            OnDragEvent(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
            OnDropEvent(this);
    }
}




