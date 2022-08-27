using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerStats = GetComponent<PlayerStats>();
    }
    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= playerStats.RunSpeed;
        }
        else
        {
            moveDirection *= playerStats.WalkSpeed;
        }

        characterController.Move(moveDirection * Time.fixedDeltaTime);
    }
}
