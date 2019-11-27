using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private GameObject turret_to_build;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build manager in scene");
        }
        instance = this;
    }

    public GameObject standard_turret_prefab;

    private void Start()
    {
        turret_to_build = standard_turret_prefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turret_to_build;
    }
}
