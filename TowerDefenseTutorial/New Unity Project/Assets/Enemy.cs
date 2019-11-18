using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypoint_index = 0;

    private void Start()
    {
        target = Waypoints.points[waypoint_index];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (direction.magnitude < 0.3f)
        {
            GetNextWaypoint();
        }
        

    }

    void GetNextWaypoint()
    {
        waypoint_index += 1;
        if (waypoint_index >= Waypoints.points.Length)
        {
            Destroy(gameObject);
        }

        target = Waypoints.points[waypoint_index];
    }

}
