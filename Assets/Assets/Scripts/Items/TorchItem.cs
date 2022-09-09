using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TorchItem : MonoBehaviour, IInteractableObject
{
    [SerializeField] private string title;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI textBox;
    [SerializeField] private AudioClip clip;

    public bool IsInterractable { get; private set; }

    public bool DestroyOnInterract { get; } = true;

    private void Start()
    {
        panel.SetActive(false);
        textBox.text = title;
    }

    public void SetInterractable(bool able)
    {
        if (IsInterractable != able)
        {
            IsInterractable = able;
            panel.SetActive(able);
        }
    }

    public void Interact(Player player)
    {
        player.PlayerController.GetTorch();
        SceneGameManager.Instance.GetTorch();
        SoundManager.Instance.InstantiateSound(clip, transform.position).Play();
        gameObject.SetActive(false);
    }
}
