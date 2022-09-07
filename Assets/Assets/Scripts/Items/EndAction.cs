using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAction : WorldAction
{
    public override void Interact(Player player)
    {
        if (SceneGameManager.Instance.IsEmergency)
        {
            print("done");
        }
    }
}
