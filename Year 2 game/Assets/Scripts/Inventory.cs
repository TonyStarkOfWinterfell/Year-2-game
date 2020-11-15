using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField] List<Item> startingItems;
    [SerializeField] Transform itemsParent;
    [SerializeField] BaseItemSlot[] itemSlots;

    public event Action<BaseItemSlot> OnRightClickEvent;
    public event Action<BaseItemSlot> OnBeginDragEvent;
    public event Action<BaseItemSlot> OnEndDragEvent;
    public event Action<BaseItemSlot> OnDragEvent;
    public event Action<BaseItemSlot> OnDropEvent;

    private void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnRightClickEvent += OnRightClickEvent;
            itemSlots[i].OnBeginDragEvent += OnBeginDragEvent;
            itemSlots[i].OnEndDragEvent += OnEndDragEvent;
            itemSlots[i].OnDragEvent += OnDragEvent;
            itemSlots[i].OnDropEvent += OnDropEvent;
        }
        SetStartingItems();
    }

    private void OnValidate()
    {
        if (itemsParent != null)
            itemSlots = itemsParent.GetComponentsInChildren<BaseItemSlot>();

        SetStartingItems();
    }

    private void SetStartingItems()
    {
        int i = 0;
        for (; i < startingItems.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = startingItems[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }




    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }

    public bool RemoveItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public bool IsFull()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return false;
    }
    
    public bool ContainsItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                return true;
            }
        }
        return false;
    }

    public int ItemCount(Item item)
    {
        int number = 0;
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                number++;
            }
        }
        return number;
    }
}