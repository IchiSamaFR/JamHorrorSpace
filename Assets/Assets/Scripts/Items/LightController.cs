using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [System.Serializable]
    public class LightData
    {
        public string Id;
        public bool Active = true;
        public List<LightBlink> Lights = new List<LightBlink>();
    }

    public static LightController Instance;

    [SerializeField] private List<LightData> lightBlinkList = new List<LightData>();

    private void Awake()
    {
        Instance = this;
    }

    public void Subscribe(LightBlink lightBlink)
    {
        string key = lightBlink.LinkedGroup;
        if (!lightBlinkList.Any(light => light.Id == key))
        {
            lightBlinkList.Add(new LightData()
            {
                Id = lightBlink.LinkedGroup
            });
        }
        LightData lightData = lightBlinkList.First(light => light.Id == lightBlink.LinkedGroup);

        lightData.Lights.Add(lightBlink);
        lightBlink.SetEnable(lightData.Active);
    }

    public void Show(string key)
    {
        if (lightBlinkList.Any(light => light.Id == key))
        {
            LightData lightData = lightBlinkList.First(light => light.Id == key);
            lightData.Active = true;
            lightData.Lights.ForEach(light => light.SetEnable(lightData.Active));
        }
    }
    public void Hide(string key)
    {
        if (lightBlinkList.Any(light => light.Id == key))
        {
            LightData lightData = lightBlinkList.First(light => light.Id == key);
            lightData.Active = false;
            lightData.Lights.ForEach(light => light.SetEnable(lightData.Active));
        }
    }
}
