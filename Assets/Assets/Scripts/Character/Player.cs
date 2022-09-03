using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [System.NonSerialized] public PlayerStats PlayerStats;
    [System.NonSerialized] public PlayerController PlayerController;
    [System.NonSerialized] public PlayerInventory PlayerInventory;
    public PlayerUI PlayerUI;

    private void Start()
    {
        PlayerStats = GetComponent<PlayerStats>();
        PlayerController = GetComponent<PlayerController>();
        PlayerInventory = GetComponent<PlayerInventory>();

        if (!PlayerUI)
        {
            Debug.LogError("Menu has not been assigned in Player.");
        }
    }
}
