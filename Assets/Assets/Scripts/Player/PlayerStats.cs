using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [Header("Inventory")]
    public int InventorySize = 3;

    [Header("Breath")]
    public float MaxPitchModifier = 0.5f;
    public float MaxVolumeModifier = 0.7f;

    [Header("Hostility")]
    public float TimeToPanic = 1.4f;
    public float TimeToPanicDown = 6;
    public float ConeRadius = 10;
    public float RangeRadius = 7;
    public float RangeInstantRadius = 2;
}
