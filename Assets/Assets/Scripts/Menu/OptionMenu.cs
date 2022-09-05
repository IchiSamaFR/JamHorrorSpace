using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    private SoundManager soundManager;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider ambientSlider;

    private void Start()
    {
        soundManager = SoundManager.Instance;
        RefreshValues();
    }

    public void RefreshValues()
    {
        sfxSlider.value = soundManager.VolumeSFX;
        ambientSlider.value = soundManager.VolumeAmbient;
    }
    public void ApplySFXValues()
    {
        soundManager.VolumeSFX = sfxSlider.value;
        soundManager.RefreshValues();
    }
    public void ApplyAmbientValues()
    {
        soundManager.VolumeAmbient = ambientSlider.value;
        soundManager.RefreshValues();
    }
}
