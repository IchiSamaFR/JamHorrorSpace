using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Menu : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera CineCamOptions;
    [SerializeField] private CinemachineVirtualCamera CineCamMain;
    [SerializeField] private CinemachineVirtualCamera CineCamOptionsReverse;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;

    // Start is called before the first frame update
    void Start() {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnExit() {
        Application.Quit();
    }

    public void OnOptions() {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);

        CineCamMain.Priority = 0;
        CineCamOptionsReverse.Priority = 0;
        CineCamOptions.Priority = 10;

        CineCamOptions.GetCinemachineComponent<CinemachineTrackedDolly>().m_AutoDolly.m_Enabled = true;
    }

    public void OnStart() {
        SceneManager.LoadScene("MainStation");
    }

    public void BackOnMenu() {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);

        CineCamMain.Priority = 0;
        CineCamOptionsReverse.Priority = 10;
        CineCamOptions.Priority = 0;

        CineCamOptionsReverse.GetCinemachineComponent<CinemachineTrackedDolly>().m_AutoDolly.m_Enabled = true;

    }
}
