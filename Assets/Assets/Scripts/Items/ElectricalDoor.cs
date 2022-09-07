using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ElectricalDoor : WorldAction
{
    private void Start()
    {
        Init();
    }
    public override void Interact(Player player)
    {
        if (SceneGameManager.Instance.IsElectrical)
        {
            base.Interact(player);
        }
    }
}
