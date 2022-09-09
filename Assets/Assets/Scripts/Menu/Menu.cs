using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    [Header("Camera")]
    [SerializeField] private CinemachineVirtualCamera CineCamOptions;
    [SerializeField] private CinemachineVirtualCamera CineCamMain;
    [SerializeField] private CinemachineVirtualCamera CineCamOptionsReverse;

    [Header("Menu")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;

    [Header("MenuButton")]
    [SerializeField] private GameObject StartBtn;
    [SerializeField] private GameObject OptionBtn;
    [SerializeField] private GameObject ExitBtn;

    [Header("LoadingScreen")]
    [SerializeField] private GameObject Loader;
    [SerializeField] private Slider LoaderBar;

    [Header("Scene")]
    [SerializeField] private Scene GameScene;

    void Start() {
        Time.timeScale = 1;
        CineCamMain.GetCinemachineComponent<CinemachineTrackedDolly>().m_AutoDolly.m_Enabled = true;
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
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

    public void StartGame() {
        StartCoroutine(LoadSceneAsync("MainStation"));
    }

    IEnumerator LoadSceneAsync(string scene) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);

        Loader.SetActive(true);

        StartBtn.SetActive(false);
        OptionBtn.SetActive(false);
        ExitBtn.SetActive(false);

        Loader.SetActive(true);

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9F);
            LoaderBar.value = progress;
            SoundManager.Instance.UnSubscribeAll();
            yield return null;
        }
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
