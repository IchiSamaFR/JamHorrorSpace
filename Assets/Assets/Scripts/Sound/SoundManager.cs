using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundType
    {
        sfx,
        ambient
    }
    public static SoundManager Instance;

    public float VolumeSFX = 1;
    public float VolumeAmbiant = 1;

    private List<Sound> sfxList = new List<Sound>();
    private List<Sound> ambientList = new List<Sound>();

    private void Awake()
    {
        Instance = this;
    }

    public void Subscribe(Sound sound)
    {
        switch (sound.Type)
        {
            default:
            case SoundType.sfx:
                sfxList.Add(sound);
                sound.SetVolume(VolumeSFX);
                break;
            case SoundType.ambient:
                ambientList.Add(sound);
                sound.SetVolume(VolumeAmbiant);
                break;
        }
    }
    public void UnSubscribe(Sound sound)
    {
        switch (sound.Type)
        {
            default:
            case SoundType.sfx:
                sfxList.Remove(sound);
                break;
            case SoundType.ambient:
                ambientList.Remove(sound);
                break;
        }
    }
    public void CreateSFXAudio(AudioClip clip, Vector3 position, float mutliplier = 1)
    {
        Sound sound = InstantiateSound(clip, position);
        sound.SetVolume(VolumeSFX);
        sound.SetMultiplier(mutliplier);
        sound.Play();
    }

    public Sound InstantiateSound(AudioClip clip, Vector3 position)
    {
        GameObject gameObject = new GameObject("SFX");
        gameObject.transform.position = position;
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.minDistance = 0;
        audio.maxDistance = 10;
        audio.spatialBlend = 0.8f;
        audio.clip = clip;
        return gameObject.AddComponent<Sound>();
    }
}
