using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeAction : WorldAction
{
    public override void Interact(Player player)
    {
        base.Interact(player);
        SceneGameManager.Instance.GetBadge();
    }
}
