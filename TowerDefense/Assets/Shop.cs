using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager build_manager;

    private void Start()
    {
        build_manager = BuildManager.instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret selected");
        build_manager.SetTurretToBuild(build_manager.standard_turret_prefab);
    }

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
        build_manager.SetTurretToBuild(build_manager.missile_launcher_prefab);
    }
}
