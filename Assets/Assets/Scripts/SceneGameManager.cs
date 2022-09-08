using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameManager : MonoBehaviour
{
    public static SceneGameManager Instance;

    public bool HasTorch;
    public bool IsElectrical;
    public bool HasBadge;
    public bool IsEmergency;

    public QuestLineUI TorchQuest;
    public QuestLineUI ElectricalQuest;
    public QuestLineUI BadgeQuest;
    public QuestLineUI EmergencyQuest;
    public QuestLineUI EscapeQuest;

    public Action OnElectricalActive;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        TorchQuest.Show();
    }

    public void GetTorch()
    {
        HasTorch = true;
        TorchQuest.Done();
        ElectricalQuest.Show();
    }
    public void UseElectrical()
    {
        IsElectrical = true;
        OnElectricalActive?.Invoke();
        ElectricalQuest.Done();
        BadgeQuest.Show();
    }
    public void GetBadge()
    {
        HasBadge = true;
        BadgeQuest.Done();
        EmergencyQuest.Show();
    }
    public void UseEmergency()
    {
        IsEmergency = true;
        EmergencyQuest.Done();
        EscapeQuest.Show();
    }
}
