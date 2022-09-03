using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public static LightController Instance;

    private Dictionary<string, List<LightBlink>> lightBlinkList = new Dictionary<string, List<LightBlink>>();

    private void Awake()
    {
        Instance = this;
    }

    public void Subscribe(LightBlink lightBlink)
    {
        string key = lightBlink.LinkedGroup;
        if (!lightBlinkList.ContainsKey(key))
        {
            lightBlinkList.Add(key, new List<LightBlink>());
        }
        lightBlinkList[key].Add(lightBlink);
    }

    public void Show(string key)
    {
        if (lightBlinkList.ContainsKey(key))
        {
            lightBlinkList[key].ForEach(light => light.SetEnable(true));
        }
    }
    public void Hide(string key)
    {
        if (lightBlinkList.ContainsKey(key))
        {
            lightBlinkList[key].ForEach(light => light.SetEnable(false));
        }
    }
}
