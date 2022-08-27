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

    private void Start()
    {
        textBox.text = item.Name;
        panel.SetActive(false);
    }

    public void SetInterractable(bool able)
    {
        if(IsInterractable != able)
        {
            IsInterractable = able;
            panel.SetActive(IsInterractable);
        }
    }
    public void Interact(Player player)
    {
        if (player.PlayerInventory.AddItem(item))
        {
            Destroy(gameObject);
        }
    }

}
