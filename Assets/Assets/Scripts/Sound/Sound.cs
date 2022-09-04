using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    private AudioSource audioSource;

    public SoundManager.SoundType Type;
    public float Volume = 1;
    public float Multiplier = 1;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        SoundManager.Instance.Subscribe(this);
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            SoundManager.Instance.UnSubscribe(this);
            Destroy(gameObject);
        }
    }
    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
    public void Stop()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
    public void SetVolume(float volume)
    {
        if (Volume != volume)
        {
            Volume = volume;
            audioSource.volume = Volume * Multiplier;
        }
    }
    public void SetMultiplier(float multiplier)
    {
        if(Multiplier != multiplier)
        {
            Multiplier = multiplier;
            audioSource.volume = Volume * Multiplier;
        }
    }
    public void SetPitch(float pitch)
    {
        audioSource.pitch = pitch;
    }
}

