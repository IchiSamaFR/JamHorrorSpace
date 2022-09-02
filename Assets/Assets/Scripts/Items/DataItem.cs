using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "Jam/DataItem")]
public class DataItem : ScriptableObject
{
    public string Id;
    public string Name;
    public string Description;
    public int Quantity;
    public Sprite Sprite;
    public GameObject Prefab;

    public DataItem Clone() {
        return new DataItem {
            Id = Id,
            Name = Name,
            Description = Description,
            Quantity = Quantity,
            Sprite = Sprite,
            Prefab = Prefab,
        };
    }
}
