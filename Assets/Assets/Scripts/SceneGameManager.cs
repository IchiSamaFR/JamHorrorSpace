using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGameManager : MonoBehaviour
{
    public static SceneGameManager Instance;

    public bool IsElectrical;
    public bool IsEmergency;

    private void Awake()
    {
        Instance = this;
    }
}
