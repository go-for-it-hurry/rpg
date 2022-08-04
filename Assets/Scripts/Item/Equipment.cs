using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipmentSlot
{
    Head,
    Chest,
    Legs,
    Weapon,
    Shield,
    Shoes,
    Hair,
    Body,
    Pants,
    Shirt
}

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipmentSlot;
    public int armorModifier = 0;
    public int damageModifier = 0;
    public SkinnedMeshRenderer meshRenderer = null;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}
