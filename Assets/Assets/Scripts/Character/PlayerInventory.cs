using System.Collections;
using System.Collections.Generic;
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
    public void DropItem(DataItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
        }
    }
}
