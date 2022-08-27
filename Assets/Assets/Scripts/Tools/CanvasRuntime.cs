using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRuntime : MonoBehaviour
{
    void Start()
    {
        if (GetComponent<Canvas>())
        {
            GetComponent<Canvas>().worldCamera = Camera.main;
        }
        else
        {
            Debug.LogError("No camera detected.");
        }
    }
}
