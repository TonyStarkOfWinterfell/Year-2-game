﻿using UnityEngine;


public class Inventory : ItemContainer
{
    [SerializeField] Item[] startingItems; 
    [SerializeField] Transform itemsParent; 
       
        
    protected override void OnValidate()   
    {
        if (itemsParent != null)
            itemsParent.GetComponentsInChildren(includeInactive: true, result: itemSlots);

        SetStartingItems();
    }

    protected override void Awake()
    {
        base.Awake();
        SetStartingItems();
    }

    private void SetStartingItems()
    {
        Clear();
        foreach (Item item in startingItems)
        {
            AddItem(item.GetCopy());
        }
    }

}