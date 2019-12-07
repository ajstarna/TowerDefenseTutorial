using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;
    public float explosion_radius = 0f;
    public int damage = 50;

    public GameObject impact_effect;

    public void Seek (Transform _target)
    {
        this.target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance_this_frame = speed * Time.deltaTime;
        if (direction.magnitude <= distance_this_frame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance_this_frame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget ()
    {
        GameObject effect_instance = Instantiate(impact_effect, transform.position, transform.rotation);
        Destroy(effect_instance, 2f);

        if (explosion_radius > 0) 
        {
            Explode();
        }
        else 
        {
            Damage(target);
        }

        Destroy(this.gameObject);
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>(); // the Enemy script component
        if (e != null)
        {
            e.TakeDamage(damage);   
        }
    }

    void Explode ()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, explosion_radius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosion_radius);

    }
}
