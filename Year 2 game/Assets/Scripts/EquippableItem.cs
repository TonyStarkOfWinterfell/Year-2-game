﻿
using UnityEngine;

public enum EquipmentType
{
    Helmet,
    Weapon,
    Shield,
    Body,
    Knife,
}

[CreateAssetMenu]
public class EquippableItem : Item
{
    //[Space]
    public EquipmentType EquipmentType;
    //variable for whats equiped


    public void Equip(Character c)
    {
        //if variable = axe thenmine speed = minespeed*2??
    }

    public void Unequip(Character c)
    {
        //part 3 tutorial
    }
}

