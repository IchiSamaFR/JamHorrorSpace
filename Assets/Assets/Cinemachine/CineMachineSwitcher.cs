using UnityEngine;
using Cinemachine;
using System.Collections;

public class CineMachineSwitcher : MonoBehaviour {

    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private PlayerController player;
    [SerializeField] private CinemachineVirtualCamera trakingCamera;

    private float wait = 5;
    private void Start()
    {
        StartCoroutine("ResumeMovement");
    }

    private IEnumerator ResumeMovement()
    {
        yield return new WaitForSeconds(wait);
        trakingCamera.Priority = 0;
        mainCamera.Priority = 10;
        player.ResumeMovement();
    } 

}
