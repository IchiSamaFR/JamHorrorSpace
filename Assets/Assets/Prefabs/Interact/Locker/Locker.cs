using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : WorldAction
{
    [SerializeField]
    private bool ImIn;

    void Start()
    {
        Init();
    }

    public override void Interact(Player player) {
        base.Interact(player);
        if (ImIn) {
            player.PlayerController.ShowPlayer();
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.PlayerController.ResumeMovement();
            ImIn = false;
        } else {
            player.PlayerController.HidePlayer();
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.PlayerController.StopMovement();
            ImIn = true;
        }
       
    }

}
