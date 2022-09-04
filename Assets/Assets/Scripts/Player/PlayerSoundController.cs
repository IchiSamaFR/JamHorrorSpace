using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    private Player player;
    private PlayerStats playerStats;

    public Player Player
    {
        get
        {
            if (player == null)
            {
                player = GetComponent<Player>();
            }
            return player;
        }
    }
    public PlayerStats PlayerStats
    {
        get
        {
            if(playerStats == null)
            {
                playerStats = Player.PlayerStats;
            }
            return playerStats;
        }
    }

    [Header("Loop sounds")]
    [SerializeField] private Sound ambiant;
    [SerializeField] private Sound breath;

    [Header("Create sounds")]
    [SerializeField] private List<AudioClip> footSteps;
    [SerializeField] private List<AudioClip> actions;


    public void SetBreathSound(float percent)
    {
        percent = Mathf.Clamp(percent, 0, 1);
        breath.SetPitch(1 + PlayerStats.MaxPitchModifier * percent);
        breath.SetMultiplier((1 - PlayerStats.MaxVolumeModifier) +
            PlayerStats.MaxVolumeModifier * percent);
    }
    public void PlayFootStep()
    {
        AudioClip clip = footSteps[Random.Range(0, footSteps.Count)];
        SoundManager.Instance.CreateSFXAudio(clip, transform.position, 1f);
    }
    public void PlaySneakFootStep()
    {
        AudioClip clip = footSteps[Random.Range(0, footSteps.Count)];
        SoundManager.Instance.CreateSFXAudio(clip, transform.position, 0.5f);
    }
    public void PlayAction()
    {
        SoundManager.Instance.CreateSFXAudio(actions[Random.Range(0, actions.Count)], transform.position);
    }

}
