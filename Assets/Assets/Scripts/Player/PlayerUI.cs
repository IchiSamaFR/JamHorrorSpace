using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool isOpen;

    void Start()
    {
        if (!menu)
        {
            Debug.LogError("Menu has not been assigned in PlayerUI.");
        }
        menu.SetActive(false);
    }

    public void Show() {
        isOpen = !isOpen;
        menu.SetActive(isOpen);

        Time.timeScale = isOpen ? 0 : 1;
    }
    public void Resume() {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
