
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Weapon,
    Shield,
    Body,
    Knife,
}

[CreateAssetMenu(menuName = "Items/Equippable Item")]
public class EquippableItem : Item
{
    //[Space]
    public EquipmentType EquipmentType;
    
    public override Item GetCopy()
    {
        return Instantiate(this);
    }

    public override void Destroy()
    {
        Destroy(this);
    }

    
    public void Equip(Character c)
    {
        
    }

    public void Unequip(Character c)
    {
        
    }
    
    /*
    public override string GetItemType()
    {
        return EquipmentType.ToString();
    }


    //extra stuff nott added for tool tips
    */
}

