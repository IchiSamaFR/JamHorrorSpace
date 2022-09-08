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

    void GoTo(Waypoint newPoint) {
        print(atm.name);
        print(newPoint.name);
        lastWaypoint = atm;
        atm = newPoint;
        animator.SetBool("IsWalking",true);
        Movement();
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

    void ChangeWaypoint() {
        print("------");
        foreach (var item in atm.waypoints)
        {
            print(item.name);
        }
        if(atm.waypoints.Length == 1)
        {
            GoTo(atm.waypoints[0]);
            return;
        }
        for (int i = 0; i < atm.waypoints.Length; i++) {
            int e = Random.Range(0, atm.waypoints.Length);
            GoTo(atm.waypoints[e]);
        }
    }
}


