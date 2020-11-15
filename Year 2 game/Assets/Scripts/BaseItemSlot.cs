using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BaseItemSlot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] Image image;

    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);

    [SerializeField] Item _item;
    public Item Item
    {
        get { return _item;  }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.sprite = null; // new
                image.color = disabledColor;
            }
            else
            {
                image.sprite = _item.Icon;
                image.color = normalColor;

            }

        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Right)
        {
            if (OnRightClickEvent != null)
                OnRightClickEvent(this);
        }
    }

    protected virtual void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
        
    }

    public virtual bool CanRecieveItem(Item item)
    {
        return true;
    }

    Vector2 originalPosition;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null)
        {
            OnBeginDragEvent(this);
        }

        originalPosition = image.transform.position;
        //Debug.Log(_item.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null)
        {
            OnEndDragEvent(this);
        }

        image.transform.position = originalPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null)
        {
            OnDragEvent(this);
        }

        image.transform.position = Input.mousePosition;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null)
        {
            OnDropEvent(this);
        }
        //throw new NotImplementedException();
    }
}
