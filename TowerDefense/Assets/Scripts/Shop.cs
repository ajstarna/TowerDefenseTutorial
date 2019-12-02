using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standard_turret;
    public TurretBlueprint missile_launcher;

    BuildManager build_manager;

    private void Start()
    {
        build_manager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        build_manager.SetTurretToBuild(standard_turret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
        build_manager.SetTurretToBuild(missile_launcher);
    }
}
