using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    [Header("Loop sounds")]
    [SerializeField] private Sound ambiant;
    [SerializeField] private Sound breath;

    [Header("Create sounds")]
    [SerializeField] private List<AudioClip> footSteps;
    [SerializeField] private List<AudioClip> actions;

    public void SetBreathSound(int amount)
    {
        amount = Mathf.Clamp(amount, 0, 100);
        breath.SetPitch(1 + 2 * (amount / 100));
    }
    public void PlayFootStep()
    {
        AudioClip clip = footSteps[Random.Range(0, footSteps.Count)];
        SoundManager.Instance.CreateSFXAudio(clip, transform.position, 0.3f);
    }
    public void PlaySneakFootStep()
    {
        AudioClip clip = footSteps[Random.Range(0, footSteps.Count)];
        SoundManager.Instance.CreateSFXAudio(clip, transform.position, 0.15f);
    }
    public void PlayAction()
    {
        SoundManager.Instance.CreateSFXAudio(actions[Random.Range(0, actions.Count)], transform.position);
    }

}
