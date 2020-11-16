
using UnityEngine;

public class ItemContainer : MonoBehaviour, IItemContainer
{
    [SerializeField] protected ItemSlot[] itemSlots;

    public virtual bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null || (itemSlots[i].Item.ID == item.ID && itemSlots[i].Amount < item.MaximumStacks)
            {
                itemSlots[i].Item = item;
                return true;
            }
        }
        return false;
    }
}
