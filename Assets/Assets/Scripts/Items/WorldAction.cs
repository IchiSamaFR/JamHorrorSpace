using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WorldAction : MonoBehaviour, IInteractableObject
{
    [Header("UI")]
    [SerializeField] protected string title;
    [SerializeField] protected GameObject panel;
    [SerializeField] protected TextMeshProUGUI textBox;

    [Header("Items")]
    [SerializeField] protected List<string> itemConsumed;
    [SerializeField] protected bool useMultipleTime;

    [Header("Actions")]
    [SerializeField] protected GameObject objectBefore;
    [SerializeField] protected GameObject objectAppeared;
    [SerializeField] protected AudioClip audioUse;
    [SerializeField] protected AudioClip audioUnUse;

    [SerializeField] private bool active;

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
            IsInterractable = able;
            panel.SetActive(IsInterractable);
        }
    }

    public virtual void Interact(Player player) {
        print("Interact");
        active = !active;
        if (!itemConsumed.Any(item => !player.PlayerInventory.HasItem(item)))
        {
            active = !active;
            if (!useMultipleTime)
            {
                SetInterractable(false);
            }
            itemConsumed.ForEach(item => player.PlayerInventory.RemoveItem(item));

            objectBefore?.SetActive(active);
            objectAppeared?.SetActive(!active);
        }

        if (active) {
            if (audioUse) {
                SoundManager.Instance.InstantiateSound(audioUse, transform.position);
            }
        } else {
            if (audioUnUse) {
                SoundManager.Instance.InstantiateSound(audioUnUse, transform.position);
            }
        }
    }
}
