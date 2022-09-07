using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyDoor : WorldAction
{
    [SerializeField] private GameObject lightObj;

    private void Start()
    {
        Init();
    }
    public override void Interact(Player player)
    {
        if (SceneGameManager.Instance.HasBadge)
        {
            base.Interact(player);
        }
    }
}
