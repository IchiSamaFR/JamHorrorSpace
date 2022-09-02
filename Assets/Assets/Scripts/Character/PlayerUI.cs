using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show() {
        isOpen = !isOpen;
        menu.SetActive(isOpen);

        Time.timeScale = isOpen ? 0 : 1;
    }

    public void OnResume() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
