using UnityEngine;
using Cinemachine;

public class CineMachineSwitcher : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private PlayerController player;
    [SerializeField] private CinemachineVirtualCamera trakingCamera;

    private float wait = 5;

    void Update()
    {

        wait -= Time.deltaTime;
        if (wait <= 0) {
            trakingCamera.Priority = 0;
            mainCamera.Priority = 10;
            player.ResumeMovement();
        }
    }

}
