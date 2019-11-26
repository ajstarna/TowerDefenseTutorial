using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;
    public float speed = 70f;

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
    }

    void HitTarget ()
    {
        GameObject effect_instance = Instantiate(impact_effect, transform.position, transform.rotation);
        Destroy(effect_instance, 2f);

        Destroy(target.gameObject);
        Destroy(this.gameObject);
    }
}
