using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private PlayerInventoryUI playerInventoryUi;

    public List<DataItem> items = new List<DataItem>();

    private int maxItems = 3;

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    public bool AddItem(DataItem i)
    {
        DataItem item = HasItem(i.Id);
        if (item) {
            item.Quantity++;
            playerInventoryUi.Refresh(items);
            return true;
        }
        if (items.Count >= maxItems) {
            return false;
        }
        if (items.Count < playerStats.InventorySize)
        {
            items.Add(i.Clone());
            playerInventoryUi.Refresh(items);
            return true;
        }
        return false;
    }
    public bool RemoveItem(string itemId)
    {
        DataItem item = HasItem(itemId);
        if (item) {
            if (item.Quantity > 1) {
                item.Quantity--;
                playerInventoryUi.Refresh(items);
                return true;
            } else {
                items.Remove(item);
            }
        }
        return false;
    }

    public DataItem HasItem(string itemId)
    {
        if (items.Any(i => i.Id == itemId)) {
            return items.First(i => i.Id == itemId);
        }
        return null;
    }

    public void Drop() {
        DataItem item = items.First();
        Instantiate(item.Prefab);
        RemoveItem(item.Id);
    }
}
