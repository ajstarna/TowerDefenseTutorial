using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool allow_movement = true;

    public float pan_speed = 30f;
    public float scroll_speed = 5f;
    public float pan_border_thickness = 10f;

    public float min_y = 10f;
    public float max_y = 80f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            allow_movement = !allow_movement;
        }
        if (!allow_movement)
        {
            return;
        }

        // all the directions are rotated from what you expect
        // I guess I have the whole scene rotated wrongly around Z, oh well
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - pan_border_thickness)
        {
            transform.Translate(Vector3.right * pan_speed *Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= pan_border_thickness)
        {
            transform.Translate(Vector3.left * pan_speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= pan_border_thickness)
        {
            transform.Translate(Vector3.forward * pan_speed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - pan_border_thickness)
        {
            transform.Translate(Vector3.back * pan_speed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scroll);

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scroll_speed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, min_y, max_y);

        transform.position = pos;
    }
}
