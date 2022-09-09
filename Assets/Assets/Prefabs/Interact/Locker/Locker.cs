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
            player.PlayerController.Hide(false);
            ImIn = false;
        } else {
            player.PlayerController.HidePlayer();
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.PlayerController.StopMovement();
            player.PlayerController.Hide(true);
            ImIn = true;
        }
       
    }

}
