using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int waypoint_index = 0;

    public int health = 100;
    public int money_gain = 50;

    public GameObject death_effect;

    private void Start()
    {
        target = Waypoints.points[waypoint_index];
    }


    public void TakeDamage(int amount)
    {
        health -= amount;

        if ( health <= 0)
        {
            Die();
        }
    }
    private void Die ()
    {
        PlayerStats.money += money_gain;
        GameObject effect = (GameObject)Instantiate(death_effect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(this.gameObject);
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
            EndPath();
            return; // return so that we do not attempt to find the next target out of range
        }

        target = Waypoints.points[waypoint_index];
    }

    void EndPath ()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }

}
