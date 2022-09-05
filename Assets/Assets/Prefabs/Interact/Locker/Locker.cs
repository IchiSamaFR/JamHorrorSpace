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
            player.GetComponent<PlayerController>().ShowPlayer();
            player.GetComponent<Rigidbody>().isKinematic = false;
            player.GetComponent<PlayerController>().ResumeMovement();
            ImIn = false;
        } else {
            player.GetComponent<PlayerController>().HidePlayer();
            player.GetComponent<Rigidbody>().isKinematic = true;
            player.GetComponent<PlayerController>().StopMovement();
            ImIn = true;
        }
       
    }

}
