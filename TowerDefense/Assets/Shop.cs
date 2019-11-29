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

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another turret selected");
        build_manager.SetTurretToBuild(build_manager.another_turret_prefab);
    }
}
