using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hover_color;
    public Vector3 position_offset;

    private GameObject turret;

    private Renderer rend;
    private Color start_color;

    void Start()
    {
        start_color = GetComponent<Renderer>().material.color;
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cannot build on top of existing turret");
            return;
        }

        GameObject turret_to_build = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turret_to_build, transform.position + position_offset, transform.rotation);
        
    }
    void OnMouseEnter()
    {
        rend.material.color = hover_color;
    }

    void OnMouseExit()
    {
        rend.material.color = start_color;
    }
}
