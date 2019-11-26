using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float fire_rate = 1f;
    private float fire_countdown = 0f;
    public float range = 15f;

    [Header("Unity Setup Fields")]
    public string enemy_tag = "Enemy";
    public Transform part_to_rotate;
    public float turn_speed = 10f;

    public GameObject bullet_prefab;
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemy_tag);

        float closest_distance = Mathf.Infinity;
        GameObject nearest_enemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance_to_enemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance_to_enemy < closest_distance)
            {
                closest_distance = distance_to_enemy;
                nearest_enemy = enemy;
            }
        }

        if (nearest_enemy != null && closest_distance <= range)
        {
            target = nearest_enemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion look_rotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(part_to_rotate.rotation, look_rotation, Time.deltaTime * turn_speed).eulerAngles;
        part_to_rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fire_countdown <= 0f)
        {
            Shoot();
            fire_countdown = 1f / fire_rate;
        }

        fire_countdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Debug.Log("SHOOT");
        GameObject bulletGO = (GameObject)Instantiate(bullet_prefab, firepoint.position, firepoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
