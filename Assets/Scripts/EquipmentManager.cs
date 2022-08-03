using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    private Equipment[] currentEquipments;
    private Inventory inventory;

    public delegate void OnEquipmentChanged(Equipment newEquipment, Equipment oldEquipment);
    public OnEquipmentChanged onEquipmentChanged = null;

    void Start()
    {
        inventory = Inventory.instance;
        int slotsNum = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipments = new Equipment[slotsNum];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnEquipAll();
        }
    }

    public void Equip(Equipment newEquipment)
    {
        int slotIndex = (int)newEquipment.equipmentSlot;
        Equipment oldEquipment = currentEquipments[slotIndex];
        if (oldEquipment != null)
        {
            inventory.Add(oldEquipment);
        }
        currentEquipments[slotIndex] = newEquipment;
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged(newEquipment, oldEquipment);
        }
    }

    public void UnEquip(int slotIndex)
    {
        Equipment oldEquipment = currentEquipments[slotIndex];
        if (oldEquipment != null)
        {
            inventory.Add(oldEquipment);
            currentEquipments[slotIndex] = null;
            if (onEquipmentChanged != null)
            {
                onEquipmentChanged(null, oldEquipment);
            }
        }
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipments.Length; i++)
        {
            UnEquip(i);
        }
    }
}
