using UnityEngine;


public class Inventory : ItemContainer
{
    [SerializeField] Item[] startingItems; //protected?
    [SerializeField] Transform itemsParent;  //protected?
       
        
    protected override void OnValidate()   //protect override ? inf inv? link to proc above
    {
        if (itemsParent != null)
            itemSlots = GetComponentsInChildren<ItemSlot>(includeInactive: true);//, result: ItemSlots);

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