using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject classique;
    [SerializeField] private GameObject options;
    private bool isOpen;

    void Start()
    {
        if (!menu)
        {
            Debug.LogError("Menu has not been assigned in PlayerUI.");
        }
        menu.SetActive(false);
        Cursor.visible = false;
    }

    public void Show() {
        isOpen = !isOpen;
        Cursor.visible = isOpen;
        menu.SetActive(isOpen);

        Time.timeScale = isOpen ? 0 : 1;
        if (isOpen)
        {
            SoundManager.Instance.Stop();
        }
        else
        {
            SoundManager.Instance.Play();
        }
    }
    public void Resume() {
        Show();
    }

    public void ExitToMainMenu()
    {
        GameManager.LoadScene("MainMenu");
    }

    public void GoOptions() {
        classique.SetActive(false);
        options.SetActive(true);
    }

    public void BackMenu() {
        classique.SetActive(true);
        options.SetActive(false);
    }
}
