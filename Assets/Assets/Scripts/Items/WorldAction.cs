using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WorldAction : MonoBehaviour, IInteractableObject
{
    [Header("UI")]
    [SerializeField] private string title;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI textBox;

    [Header("Items")]
    [SerializeField] private List<string> itemConsumed;
    [SerializeField] private bool useMultipleTime;

    [Header("Actions")]
    [SerializeField] private GameObject objectBefore;
    [SerializeField] private GameObject objectAppeared;
    [SerializeField] private AudioClip audioUse;
    [SerializeField] private AudioClip audioUnUse;

    private bool active;

    public bool IsInterractable { get; private set; }
    public bool DestroyOnInterract { get; private set; }

    private void Start()
    {
        textBox.text = title;
        panel.SetActive(false);
        objectBefore?.SetActive(true);
        objectAppeared?.SetActive(false);
    }

    public void SetInterractable(bool able)
    {
        if (IsInterractable != able && !active && !useMultipleTime)
        {
            print("can interract");
            IsInterractable = able;
            panel.SetActive(IsInterractable);
        }
    }

    public void Interact(Player player) {
        if(!itemConsumed.Any(item => !player.PlayerInventory.HasItem(item)))
        {
            print("act");
            if (!useMultipleTime)
            {
                active = !active;
                SetInterractable(false);
            }
            itemConsumed.ForEach(item => player.PlayerInventory.RemoveItem(item));

            objectBefore?.SetActive(active);
            objectAppeared?.SetActive(!active);

            if (active)
            {
                if (audioUse)
                {
                    SoundManager.Instance.InstantiateSound(audioUse, transform.position);
                }
            }
            else
            {
                if (audioUnUse)
                {
                    SoundManager.Instance.InstantiateSound(audioUnUse, transform.position);
                }
            }
        }
    }
}
