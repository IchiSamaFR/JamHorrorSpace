using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Creature : MonoBehaviour
{
    [SerializeField] private Waypoint[] IA;
    private Waypoint lastWaypoint = null;
    [SerializeField] private Waypoint atm;
    [SerializeField] private Animator animator;
    [SerializeField] private bool canMove = false;
    [SerializeField] private Player player;

    [SerializeField] private GameObject uiEnd;
    [SerializeField] private Sound soundChase;

    [Header("NavMesh")]
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private float lowRange = 0.5f;
    [SerializeField] private float range = 8f;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float timeChase = 3;
    private Vector3 lastPlayerPos = new Vector3();
    public bool IsChasing;
    float timerChase;

    private void Awake()
    {

    }

    private void Start()
    {
        if (!canMove) {
            return;
        }
        transform.position = atm.transform.position;
    }

    void Update()
    {
        if (!canMove) {
            return;
        }
        Movement();
        CheckPlayer();
    }

    void GoTo(Waypoint newPoint)
    {
        lastWaypoint = atm;
        atm = newPoint;
        lastPlayerPos = atm.transform.position;
        animator.SetBool("IsWalking", true);
        navMeshAgent.SetDestination(atm.transform.position);
    }

    void Movement()
    {
        if(IsChasing)
        {
            if (transform.position.x <= lastPlayerPos.x + 0.1f && transform.position.x >= lastPlayerPos.x - 0.1f &&
                transform.position.z <= lastPlayerPos.z + 0.1f && transform.position.z >= lastPlayerPos.z - 0.1f)
            {
                IsChasing = false;
                navMeshAgent.SetDestination(atm.transform.position);
            }
        }
        else
        {
            if (transform.position.x <= atm.transform.position.x + 0.1f && transform.position.x >= atm.transform.position.x - 0.1f &&
                transform.position.z <= atm.transform.position.z + 0.1f && transform.position.z >= atm.transform.position.z - 0.1f)
            {
                ChangeWaypoint();
            }
        }
    }
    void CheckPlayer()
    {
        var heading = player.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), direction, out hit, range, mask)
            && hit.transform.GetComponent<Player>() && !player.PlayerController.IsHide)
        {
            if(hit.distance <= lowRange)
            {
                YouDie();
            }
            timerChase = timeChase;
        }
        if(timerChase > 0)
        {
            soundChase.SetMultiplier(1);
            timerChase -= Time.deltaTime;
            IsChasing = true;
            lastPlayerPos = player.transform.position;
            navMeshAgent.SetDestination(lastPlayerPos);
        }
        else
        {
            IsChasing = false;
            soundChase.SetMultiplier(0.3f);
            navMeshAgent.SetDestination(atm.transform.position);
        }
    }

    void ChangeWaypoint()
    {
        int rdm = Random.Range(0, IA.Length);

        GoTo(IA[rdm]);
    }

    // Méthode quand tu rentre dans la range trop proche de la créature
    public void YouDie() {
        Time.timeScale = 0;
        uiEnd.SetActive(true);
    }

    public void Restart()
    {
        GameManager.LoadScene("MainStation");
    }
    public void YouDieBackToMenu()
    {
        GameManager.LoadScene("MainMenu");
    }
}


