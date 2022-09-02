using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldItem : MonoBehaviour, IInteractableObject
{
    [SerializeField] private DataItem item;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI textBox;

    public bool IsInterractable { get; private set; }

    private void Start() {
        panel.SetActive(false);
        textBox.text = item.Name;
    }

    public void SetInterractable(bool able)
    {
        if(IsInterractable != able)
        {
            IsInterractable = able;
            panel.SetActive(able);
        }
    }

    public void Interact(Player player) {
        player.PlayerInventory.AddItem(item);
        Destroy(gameObject);
    }
}
