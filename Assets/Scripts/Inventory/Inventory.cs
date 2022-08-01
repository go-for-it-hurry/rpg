using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("already exist Inventory");
            return;
        }
        instance = this;
    }

    #endregion
    public int space = 2;

    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback = null;

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough space");
                return false;
            }
            items.Add(item);
            if (onItemChangedCallback != null)
            {
                onItemChangedCallback();
            }
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback();
        }
    }
}
