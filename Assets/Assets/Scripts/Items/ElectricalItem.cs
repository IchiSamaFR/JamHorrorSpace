using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ElectricalItem : WorldAction
{
    [Header("EmergencyItem")]
    [SerializeField] private string lightsId;
    private void Start()
    {
        Init();
    }

    public override void Interact(Player player)
    {
        base.Interact(player);
        LightController.Instance.Show(lightsId);
        SceneGameManager.Instance.IsElectrical = true;
    }
}
