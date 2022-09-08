using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private Waypoint[] IA;
    private Waypoint lastWaypoint = null;
    [SerializeField] private Waypoint atm;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    private void Start()
    {
        transform.position = atm.transform.position;
    }
    void Update()
    {
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
}


