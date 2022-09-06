using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    [SerializeField] private GameObject lightModel;
    public string LinkedGroup = "default";
    public float MinBeforeBlink;
    public float MaxBeforeBlink;
    public float MinBlinkDuration;
    public float MaxBlinkDuration;

    [Header("States")]
    public bool IsEnable;
    public bool IsActive;

    private void Start()
    {
        LightController.Instance.Subscribe(this);
        SetEnable(IsEnable);
    }

    public IEnumerator Blink()
    {
        while (IsEnable)
        {
            if (MaxBeforeBlink != 0)
            {
                Active(false);
                yield return new WaitForSeconds(Random.Range(MinBeforeBlink, MaxBeforeBlink));
            }
            if (IsEnable)
            {
                Active(true);
                yield return new WaitForSeconds(Random.Range(MinBlinkDuration, MaxBlinkDuration));
            }
        }
    }

    private void Active(bool active)
    {
        lightModel.SetActive(active);
    }

    public void SetEnable(bool enable)
    {
        IsEnable = enable;
        if (!IsEnable)
        {
            Active(false);
        }
        else
        {
            StopCoroutine("Blink");
            StartCoroutine("Blink");
        }
    }
}
