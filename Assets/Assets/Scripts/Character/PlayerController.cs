using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;
    private PlayerStats playerStats;
    private Camera cam;
    [SerializeField] private Animator animator;

    private Vector3 moveDirection = Vector3.zero;
    private float speed = 0;

    [SerializeField] private GameObject flashLight;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask interractableLayer;
    private IInteractableObject selectedInteractableObject;


    private void Start()
    {
        player = GetComponent<Player>();
        playerStats = GetComponent<PlayerStats>();
        cam = Camera.main;
    }
    private void Update()
    {
        CheckInterraction();
    }
    private void FixedUpdate()
    {
        Rotation();
        Movement();

        CheckInterractionAble();
    }

    private void CheckInterraction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            selectedInteractableObject?.Interact(player);
        }
    }
    private void CheckInterractionAble()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = cam.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, interractableLayer))
        {
            var heading = hit.point - transform.position;
            var distance = heading.magnitude;
            if (distance < playerStats.InterractionRange)
            {
                SelectInteractableObject(hit.transform.GetComponent<IInteractableObject>());
                return;
            }
        }
        SelectInteractableObject(null);
    }
    private void SelectInteractableObject(IInteractableObject newInteractableObject)
    {
        if (newInteractableObject != selectedInteractableObject)
        {
            if (!selectedInteractableObject?.Equals(null) ?? false)
            {
                selectedInteractableObject.SetInterractable(false);
            }
            if (!newInteractableObject?.Equals(null) ?? false)
            {
                newInteractableObject.SetInterractable(true);
            }

            selectedInteractableObject = newInteractableObject;
        }
    }
    private void Rotation()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = cam.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, groundLayer))
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
    private void Movement()
    {
        moveDirection = new Vector3();
        moveDirection += new Vector3(transform.right.x, 0, transform.right.z) * Input.GetAxis("Horizontal");
        moveDirection += new Vector3(transform.forward.x, 0, transform.forward.z) * Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift) && moveDirection != new Vector3())
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsWalking", false);
            speed += playerStats.RunSpeed * playerStats.AccelerationMultiplier * Time.fixedDeltaTime;
            speed = Mathf.Clamp(speed, 0, playerStats.RunSpeed);
        }
        else if(moveDirection != new Vector3())
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", true);
            speed += playerStats.WalkSpeed * playerStats.AccelerationMultiplier * Time.fixedDeltaTime;
            speed = Mathf.Clamp(speed, 0, playerStats.WalkSpeed);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", false);
            speed = 0;
        }

        moveDirection *= speed;
        transform.position += moveDirection * Time.fixedDeltaTime;
    }
}
