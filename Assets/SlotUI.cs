using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour
{
    public Image sprite;
    public TextMeshProUGUI quantity;

    // Start is called before the first frame update
    void Start()
    {
        sprite.gameObject.SetActive(false);
        quantity.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh(DataItem item) {
        if(item == null) {
            sprite.gameObject.SetActive(false);
            quantity.gameObject.SetActive(false);
        } else {
            sprite.sprite = item.Sprite;
            quantity.text = item.Quantity.ToString();
            sprite.gameObject.SetActive(true);
            quantity.gameObject.SetActive(true);
        }
    }
}
