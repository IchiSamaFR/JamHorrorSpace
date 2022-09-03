using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{

    public List<SlotUI> slotsUI = new List<SlotUI>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh(List<DataItem> list) {
        for (int i = 0; i < list.Count; i++) {
            slotsUI[i].Refresh(list[i]);
        }
    }
}
