using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class EmergencyItem : WorldAction
{
    [Header("EmergencyItem")]
    [SerializeField] private string lightsId;
    [SerializeField] private Sound sound;
    private void Start()
    {
        Init();
    }

    public override void Interact(Player player)
    {
        base.Interact(player);
        LightController.Instance.Show(lightsId);
        sound.SetMultiplier(0.1f);
        SceneGameManager.Instance.UseEmergency();
    }
}
