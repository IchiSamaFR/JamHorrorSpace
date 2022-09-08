using UnityEngine;

public class Creature : MonoBehaviour
{

    [SerializeField] private Waypoint[] IA;
    private Waypoint lastWaypoint = null;
    [SerializeField] private Waypoint atm;
    [SerializeField] private Animator animator;

    void Update()
    {
        Movement();
    }

    void GoTo(Waypoint newPoint) {
        lastWaypoint = atm;
        atm = newPoint;
        animator.SetBool("IsWalking",true);
        Movement();
    }

    void Movement() {
        transform.position = transform.position - atm.waypoint.transform.position * Time.deltaTime * 0.05f;
        if(transform.position.x <= atm.waypoint.transform.position.x + 0.1f && transform.position.x >= atm.waypoint.transform.position.x -0.1f &&
            transform.position.y <= atm.waypoint.transform.position.y + 0.1f && transform.position.y >= atm.waypoint.transform.position.y - 0.1f) {
            ChangeWaypoint();
        }
    }

    void ChangeWaypoint() {
        for (int i = 0; i < atm.waypoints.Length; i++) {
            // Si on a une seul possiblité alors on y vas direct et on met pas de last waypoint
            if (atm.waypoints.Length == 1) {
                lastWaypoint = null;
                GoTo(atm.waypoints[0]);
            }
            int e = Random.Range(0, atm.waypoints.Length);
            GoTo(atm.waypoints[e]);
        }
    }
}


