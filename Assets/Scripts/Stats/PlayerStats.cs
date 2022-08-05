using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    public override void Start()
    {
        base.Start();
        EquipmentManager.instance.onEquipmentChanged += onEquipmentChanged;
    }

    private void onEquipmentChanged(Equipment newEquipment, Equipment oldEquipment)
    {
        if (newEquipment != null)
        {
            armor.AddModifier(newEquipment.armorModifier);
            damage.AddModifier(newEquipment.damageModifier);
        }
        if (oldEquipment != null)
        {
            armor.RemoveModifier(oldEquipment.armorModifier);
            damage.RemoveModifier(oldEquipment.damageModifier);
        }
    }
}
