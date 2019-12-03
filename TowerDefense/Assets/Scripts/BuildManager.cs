using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turret_to_build;

    public GameObject build_effect;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("more than one build manager in scene");
        }
        instance = this;
    }

    public bool CanBuild 
    {  get {
            return turret_to_build != null;
           }
    }

    public bool HasEnoughMoney
    {
        get
        {
            return PlayerStats.money >= turret_to_build.cost;
        }
    }

    public void BuildTurretOn(Node node)
    {

        if (!HasEnoughMoney)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.money -= turret_to_build.cost;

        //GameObject turret_to_build = build_manager.GetTurretToBuild();
        GameObject turret = (GameObject)Instantiate(turret_to_build.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(build_effect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5);
        Debug.Log("Turret built: money left:" + PlayerStats.money);
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turret_to_build = turret;
    }

    
}
