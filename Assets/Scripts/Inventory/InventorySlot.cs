using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item = null;
    public Image icon;
    public Button removeButton;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnClickRemoveButton()
    {
        Debug.Log("OnClickRemoveButton");
        Inventory.instance.Remove(item);
    }

    public void OnClickUseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}
