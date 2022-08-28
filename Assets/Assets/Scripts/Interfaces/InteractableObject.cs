using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableObject
{
    bool IsInterractable { get; }

    void SetInterractable(bool able);
    void Interact(Player player);
}