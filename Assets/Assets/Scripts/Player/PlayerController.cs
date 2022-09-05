using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private PlayerStats playerStats;
    private Camera cam;
    private Creature creature;
    [SerializeField] private Animator animator;
    [SerializeField] private CinemachineVirtualCamera mainCamera;
    [SerializeField] private CinemachineVirtualCamera shakingCamera;

    private Vector3 moveDirection = Vector3.zero;
    private float speed = 0;
    private bool isSneak;
    private bool isFlashActive = true;
    private float shake;

    [SerializeField] private GameObject flashLight;
    [SerializeField] private LayerMask creatureRaycast;
    [SerializeField] private LayerMask flashLightFocus;
    [SerializeField] private LayerMask interractableLayer;
    private IInteractableObject selectedInteractableObject;


    private void Start()
    {
        creature = (GameObject.FindObjectOfType(typeof(Creature)) as Creature);
        player = GetComponent<Player>();
        playerStats = GetComponent<PlayerStats>();
        cam = Camera.main;
    }
    private void Update()
    {
        CheckCreature();
        CheckInterraction();
        ApplyAnimations();
    }
    private void FixedUpdate()
    {
        Rotation();
        Movement();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.GetComponent<WorldItem>()) {
            selectedInteractableObject = other.transform.GetComponent<WorldItem>();
            selectedInteractableObject.SetInterractable(true);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.transform.GetComponent<WorldItem>()) {
            selectedInteractableObject.SetInterractable(false);
            selectedInteractableObject = null;
        }
    }

    private void CheckCreature()
    {
        var heading = creature.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), direction, out hit, playerStats.RangeRadius, creatureRaycast)
            && hit.transform.GetComponent<Creature>())
        {
            if(hit.distance <= playerStats.RangeInstantRadius)
            {
                shakingCamera.Priority = 11;
                shake = shake >= 1 ? 1 : shake + Time.deltaTime * 10f / playerStats.TimeToPanic;
            }
            else
            {
                Vector3 rotation = Quaternion.LookRotation(heading, transform.forward).eulerAngles;
                var y = rotation.y < 180 ? rotation.y + 360 : rotation.y;
                var charY = transform.rotation.eulerAngles.y < 180 ? transform.rotation.eulerAngles.y + 360 : transform.rotation.eulerAngles.y;

                if (charY + (playerStats.ConeRadius / 2) >= y && y >= charY - (playerStats.ConeRadius / 2))
                {
                    shakingCamera.Priority = 11;
                    shake = shake >= 1 ? 1 : shake + Time.deltaTime * 1 / playerStats.TimeToPanic;
                }
                else
                {
                    shakingCamera.Priority = 9;
                    shake = shake <= 0 ? 0 : shake - Time.deltaTime * 1 / playerStats.TimeToPanicDown;
                }
            }
        }
        else if (shake > 0)
        {
            shakingCamera.Priority = 9;
            shake = shake < 0 ? 0 : shake - Time.deltaTime * 1 / playerStats.TimeToPanicDown;
        }
        player.PlayerSoundController.SetBreathSound(shake);
    }
    private void CheckInterraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (selectedInteractableObject != null)
            {
                selectedInteractableObject.Interact(player);
                if (selectedInteractableObject.DestroyOnInterract)
                {
                    selectedInteractableObject = null;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashActive = !isFlashActive;
            flashLight.SetActive(isFlashActive);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            player.PlayerUI.Show();
        }
    }
    private void Rotation()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = cam.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, flashLightFocus))
        {
            // Player rotation
            var heading = hit.point - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance; 
            transform.rotation = Quaternion.LookRotation(
                new Vector3(direction.x, 0, direction.z));

            // Flashlight rotation
            heading = hit.point - flashLight.transform.position;
            distance = heading.magnitude;
            direction = heading / distance;
            flashLight.transform.rotation = Quaternion.LookRotation(
                new Vector3(direction.x, direction.y, direction.z));
        }
    }
    private void ApplyAnimations()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", true);
        }
        else
        {
            animator.SetBool("Right", false);
            animator.SetBool("Left", false);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("Forward", true);
            animator.SetBool("Backward", false);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backward", true);
        }
        else
        {
            animator.SetBool("Forward", false);
            animator.SetBool("Backward", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSneak = !isSneak;
            animator.SetBool("IsStand", !isSneak);
            animator.SetBool("IsSneak", isSneak);
        }
    }
    private void Movement()
    {
        moveDirection = new Vector3();
        moveDirection += new Vector3(transform.right.x, 0, transform.right.z) * Input.GetAxis("Horizontal");
        moveDirection += new Vector3(transform.forward.x, 0, transform.forward.z) * Input.GetAxis("Vertical");

        if (moveDirection != new Vector3())
        {
            if (isSneak)
            {
                speed += playerStats.SneakSpeed * playerStats.AccelerationMultiplier * Time.fixedDeltaTime;
                speed = Mathf.Clamp(speed, 0, playerStats.SneakSpeed);
            }
            else
            {
                speed += playerStats.WalkSpeed * playerStats.AccelerationMultiplier * Time.fixedDeltaTime;
                speed = Mathf.Clamp(speed, 0, playerStats.WalkSpeed);
            }
        }
        else
        {
            speed = 0;
        }

        moveDirection *= speed;
        transform.position += moveDirection * Time.fixedDeltaTime;
    }
}
