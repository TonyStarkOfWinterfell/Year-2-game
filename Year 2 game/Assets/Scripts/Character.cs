using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Inventory inventory;
    public EquipmentPanel equipmentPanel;
    [SerializeField] CraftingWindow craftingWindow;
    [SerializeField] Image draggableItem;

    private BaseItemSlot dragItemSlot;

    private void Awake()
    {
        // Setup Events:
        // Right Click
        inventory.OnRightClickEvent += Equip;
        equipmentPanel.OnRightClickEvent += Unequip;
        // Begin Drag
        inventory.OnBeginDragEvent += BeginDrag;
        equipmentPanel.OnBeginDragEvent += BeginDrag;
        // End Drag
        inventory.OnEndDragEvent += EndDrag;
        equipmentPanel.OnEndDragEvent += EndDrag;
        // Drag
        inventory.OnDragEvent += Drag;
        equipmentPanel.OnDragEvent += Drag;
        // Drop
        inventory.OnDropEvent += Drop;
        equipmentPanel.OnDropEvent += Drop;
        
    }

   private void Equip(BaseItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Equip(equippableItem);
        }
    }

    private void Unequip(BaseItemSlot itemSlot)
    {
        EquippableItem equippableItem = itemSlot.Item as EquippableItem;
        if (equippableItem != null)
        {
            Unequip(equippableItem);
        }
    }

    private void BeginDrag(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            dragItemSlot = itemSlot;
            draggableItem.sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag(BaseItemSlot itemSlot)
    {
        dragItemSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(BaseItemSlot itemSlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }
    // chedk this out down
    private void Drop(BaseItemSlot dropItemSlot) 
    {
        if (dragItemSlot == null) return;

        if (dropItemSlot.CanAddStack(dragItemSlot.Item))
        {
            AddStacks(dropItemSlot);
        }

        else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
        {
            SwapItems(dropItemSlot);
        }

    }

    private void SwapItems(BaseItemSlot dropItemSlot)
    {
        EquippableItem dragItem = dragItemSlot.Item as EquippableItem;
        EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

        if (dragItemSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Unequip(this);
            if (dropItem != null) dropItem.Equip(this);
        }
        if (dropItemSlot is EquipmentSlot)
        {
            if (dragItem != null) dragItem.Equip(this);
            if (dropItem != null) dropItem.Unequip(this);
        }

        Item draggedItem = dragItemSlot.Item;
        int draggedItemAmount = dragItemSlot.Amount;

        dragItemSlot.Item = dropItemSlot.Item;
        dropItemSlot.Amount = draggedItemAmount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        dragItemSlot.Amount -= stacksToAdd;
    }






    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }

}
