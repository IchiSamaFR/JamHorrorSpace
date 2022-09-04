using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPlayer : MonoBehaviour
{
    [SerializeField] private Player player;

    public void PlayFootStep()
    {
        player.PlayerSoundController.PlayFootStep();
    }
    public void PlaySneakFootStep()
    {
        player.PlayerSoundController.PlaySneakFootStep();
    }
}
