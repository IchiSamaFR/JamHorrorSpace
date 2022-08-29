using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerStats playerStats;

    public List<DataItem> items = new List<DataItem>();

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public bool AddItem(DataItem item)
    {
        if (items.Count < playerStats.InventorySize)
        {
            items.Add(item);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool RemoveItem(DataItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            return true;
        }
        return false;
    }
    public bool RemoveItem(DataItem.DataType dataType)
    {
        DataItem item = GetItemOf(dataType);
        if (item != null)
        {
            items.Remove(item);
            return true;
        }
        return false;
    }
    public bool HasItem(DataItem.DataType dataType)
    {
        return items.Any(item => item.Type == dataType);
    }
    private DataItem GetItemOf(DataItem.DataType dataType)
    {
        if (HasItem(dataType))
        {
            return items.First(item => item.Type == dataType);
        }
        return null;
    }
}
