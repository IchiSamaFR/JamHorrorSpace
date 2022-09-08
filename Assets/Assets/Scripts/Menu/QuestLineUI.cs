using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLineUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Awake()
    {
        Hide();
    }
    public void Show()
    {
        text.gameObject.SetActive(true);
    }
    public void Hide()
    {
        text.gameObject.SetActive(false);
    }
    public void Done()
    {
        text.color = new Color(1, 0.2f, 0.2f);
    }
}
