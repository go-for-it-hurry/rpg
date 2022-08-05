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
    public SkinnedMeshRenderer targetMeshRenderer;
    private SkinnedMeshRenderer[] currentMeshRenderers;
    public Equipment[] defaultEquipments;

    void Start()
    {
        inventory = Inventory.instance;
        int slotsNum = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipments = new Equipment[slotsNum];
        currentMeshRenderers = new SkinnedMeshRenderer[slotsNum];
        EquipDefault();
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
        Equipment oldEquipment = UnEquip(slotIndex, newEquipment);
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged(newEquipment, null);
        }
        currentEquipments[slotIndex] = newEquipment;

        if (newEquipment.meshRenderer != null)
        {
            AttachToMeshRenderer(newEquipment.meshRenderer, slotIndex);
        }
    }

    public Equipment UnEquip(int slotIndex, Equipment newEquipment)
    {
        Equipment oldEquipment = currentEquipments[slotIndex];
        if (oldEquipment != null)
        {
            inventory.Add(oldEquipment);
            currentEquipments[slotIndex] = null;
            SkinnedMeshRenderer oldMeshRenderer = currentMeshRenderers[slotIndex];
            if (oldMeshRenderer != null)
            {
                Destroy(oldMeshRenderer.gameObject);
            }
        }
        if (onEquipmentChanged != null)
        {
            onEquipmentChanged(null, oldEquipment);
        }

        return oldEquipment;
    }

    public void UnEquipAll()
    {
        for (int i = 0; i < currentEquipments.Length; i++)
        {
            UnEquip(i, null);
        }
        EquipDefault();
    }

    private void EquipDefault()
    {
        foreach (Equipment item in defaultEquipments)
        {
            Equip(item);
        }
    }

    private void AttachToMeshRenderer(SkinnedMeshRenderer meshRenderer, int slotIndex)
    {
        SkinnedMeshRenderer oldMeshRenderer = currentMeshRenderers[slotIndex];
        if (oldMeshRenderer != null)
        {
            Destroy(oldMeshRenderer.gameObject);
        }
        SkinnedMeshRenderer newMeshRenderer = Instantiate<SkinnedMeshRenderer>(meshRenderer);
        newMeshRenderer.rootBone = targetMeshRenderer.rootBone;
        newMeshRenderer.bones = targetMeshRenderer.bones;
        currentMeshRenderers[slotIndex] = newMeshRenderer;
    }
}
