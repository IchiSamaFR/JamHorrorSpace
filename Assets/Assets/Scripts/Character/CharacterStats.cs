using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Movements")]
    public float WalkSpeed = 1f;
    public float RunSpeed = 2.8f;
    public float AccelerationTime = 0.15f;
    public float AccelerationMultiplier
    {
        get
        {
            return 1 / AccelerationTime;
        }
    }
}
