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
    [SerializeField] private List<DataItem.DataType> itemConsumed;
    [SerializeField] private List<DataItem.DataType> itemNeeded;

    [Header("Actions")]
    [SerializeField] private GameObject objectBefore;
    [SerializeField] private GameObject objectAppeared;


    private bool used;

    public bool IsInterractable { get; private set; }

    private void Start()
    {
        textBox.text = title;
        panel.SetActive(false);
        objectBefore?.SetActive(true);
        objectAppeared?.SetActive(false);
    }

    public void SetInterractable(bool able)
    {
        if (IsInterractable != able && !used)
        {
            IsInterractable = able;
            panel.SetActive(IsInterractable);
        }
    }

    public void Interact(Player player)
    {
        if (!itemConsumed.Any(item => !player.PlayerInventory.HasItem(item))
            && !itemNeeded.Any(item => !player.PlayerInventory.HasItem(item)))
        {
            objectBefore?.SetActive(false);
            objectAppeared?.SetActive(true);
            itemConsumed.ForEach(item => player.PlayerInventory.RemoveItem(item));
            SetInterractable(false);
            used = true;
        }
    }
}
