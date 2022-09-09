using UnityEngine;
using UnityEngine.SceneManagement;

public class Creature : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private Waypoint[] IA;
    private Waypoint lastWaypoint = null;
    [SerializeField] private Waypoint atm;
    [SerializeField] private Animator animator;
    [SerializeField] private bool canMove = false;
    [SerializeField] private Player player;

    [SerializeField] private GameObject uiEnd;

    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
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
    }

    void GoTo(Waypoint newPoint)
    {
        lastWaypoint = atm;
        atm = newPoint;
        animator.SetBool("IsWalking",true);
    }

    void Movement()
    {
        var heading = atm.transform.position - transform.position;
        var distance = heading.magnitude;
        var direction = heading / distance;
        direction.y = 0;
        transform.position += direction * Time.deltaTime * characterStats.WalkSpeed;
        if(transform.position.x <= atm.transform.position.x + 0.1f && transform.position.x >= atm.transform.position.x - 0.1f &&
            transform.position.z <= atm.transform.position.z + 0.1f && transform.position.z >= atm.transform.position.z - 0.1f) {
            ChangeWaypoint();
        }
    }

    void ChangeWaypoint()
    {
        int weight = 3;
        int rdm = Random.Range(0, ((atm.waypoints.Length - 1) * weight) + 1);
        
        foreach (var item in atm.waypoints)
        {
            if(item == lastWaypoint)
            {
                rdm -= 1;
            }
            else
            {
                rdm -= 3;
            }

            if(rdm <= 0)
            {
                GoTo(item);
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.GetComponent<Player>()) {
            RushToPlayer();
        }
    }

    // Méthode quand la créature trouve le player alors elle rush vers elle
    private void RushToPlayer() {

    }

    private void OnTriggerExit(Collider other) {
        if (other.transform.GetComponent<Player>()) {
            BackToNearestWaypoint();
        }
    }

    // Méthode quand la créature perd le player alors elle reprendre son trajet clasique
    private void BackToNearestWaypoint() {

    }

    // Méthode quand tu rentre dans la range trop proche de la créature
    public void YouDie() {
        uiEnd.SetActive(true);
    }

    public void YouDieBackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}


