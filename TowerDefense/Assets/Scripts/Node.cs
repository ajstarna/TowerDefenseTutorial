using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hover_color;
    public Vector3 position_offset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color start_color;

    BuildManager build_manager;

    void Start()
    {
        start_color = GetComponent<Renderer>().material.color;
        rend = GetComponent<Renderer>();
        build_manager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (!build_manager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Cannot build on top of existing turret");
            return;
        }

        build_manager.BuildTurretOn(this);

        //GameObject turret_to_build = build_manager.GetTurretToBuild();
        //turret = (GameObject)Instantiate(turret_to_build, transform.position + position_offset, transform.rotation);
        
    }

    public Vector3 GetBuildPosition ()
    {
        return this.transform.position + this.position_offset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!build_manager.CanBuild)
        { 
            return;
        }
        rend.material.color = hover_color;
    }

    void OnMouseExit()
    {
        rend.material.color = start_color;
    }
}
