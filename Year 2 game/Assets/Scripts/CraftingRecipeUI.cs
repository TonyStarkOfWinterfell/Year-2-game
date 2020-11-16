using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipeUI : MonoBehaviour
{
    [SerializeField] RectTransform arrowParent;
    [SerializeField] BaseItemSlot[] itemSlots;

    [Header("Public Variables")]
    public IItemContainer ItemContainer; // problem

    private CraftingRecipe craftingRecipe;
    public CraftingRecipe CraftingRecipe
    {
        get { return CraftingRecipe; }
        set { SetCraftingRecipe(value); }
    }

    public event Action<BaseItemSlot> OnPointerEnterEvent;
    public event Action<BaseItemSlot> OnPointerExitEvent;

    private void OnValidate()
    {
        itemSlots = GetComponentsInChildren<BaseItemSlot>(includeInactive: true);
    }

    private void Start()
    {
        foreach (BaseItemSlot itemSlot in itemSlots)
        {
            itemSlot.OnPointerEnterEvent += OnPointerEnterEvent;
            itemSlot.OnPointerExitEvent += OnPointerExitEvent;
        }
    }
}
