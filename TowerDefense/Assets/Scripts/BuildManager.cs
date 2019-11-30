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
    public GameObject missile_launcher_prefab;

    public GameObject GetTurretToBuild()
    {
        return turret_to_build;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turret_to_build = turret;
    }
}
