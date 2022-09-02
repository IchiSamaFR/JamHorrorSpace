using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(PlayerUI))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [System.NonSerialized] public PlayerStats PlayerStats;
    [System.NonSerialized] public PlayerController PlayerController;
    [System.NonSerialized] public PlayerInventory PlayerInventory;
    [System.NonSerialized] public PlayerUI PlayerUI;

    private void Start()
    {
        PlayerStats = GetComponent<PlayerStats>();
        PlayerController = GetComponent<PlayerController>();
        PlayerInventory = GetComponent<PlayerInventory>();
        PlayerUI = GetComponent<PlayerUI>();
    }
}
