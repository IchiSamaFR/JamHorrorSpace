using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "Jam/DataItem")]
public class DataItem : ScriptableObject
{
    public enum DataType
    {
        cable
    }
    public DataType Type;
    public string Name;
    public GameObject Prefab;
}
