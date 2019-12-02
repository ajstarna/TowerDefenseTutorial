using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private TurretBlueprint turret_to_build;

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

    public void BuildTurretOn(Node node)
    {

        if (PlayerStats.money < turret_to_build.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }
        PlayerStats.money -= turret_to_build.cost;

        //GameObject turret_to_build = build_manager.GetTurretToBuild();
        GameObject turret = (GameObject)Instantiate(turret_to_build.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Turret built: money left:" + PlayerStats.money);
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turret_to_build = turret;
    }

    
}
