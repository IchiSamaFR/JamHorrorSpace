using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameManager : MonoBehaviour
{
    public static SceneGameManager Instance;

    public bool HasTorch;
    public bool CanOpenElectrical;
    public bool IsElectrical;
    public bool HasBadge;
    public bool IsEmergency;

    public Action OnElectricalActive;
    private void Awake()
    {
        Instance = this;
    }

    public void GetTorch()
    {
        HasTorch = true;
    }
    public void GetElectricalOpener()
    {
        CanOpenElectrical = true;
    }
    public void UseElectrical()
    {
        IsElectrical = true;
        OnElectricalActive?.Invoke();
    }
    public void GetBadge()
    {
        HasBadge = true;
    }
    public void UseEmergency()
    {
        IsEmergency = true;
    }
}
