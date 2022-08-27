using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerStats))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerInventory))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public CharacterController CharacterController;
    public PlayerStats PlayerStats;
    public PlayerController PlayerController;
    public PlayerInventory PlayerInventory;

    private void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        PlayerStats = GetComponent<PlayerStats>();
        PlayerController = GetComponent<PlayerController>();
        PlayerInventory = GetComponent<PlayerInventory>();
    }
}
