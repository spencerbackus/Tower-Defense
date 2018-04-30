using UnityEngine;

public class Shop : MonoBehaviour {
    public TurretBlueprint standardTurret;
    public TurretBlueprint advancedTurret;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance; //null error without this
    }
    public void SelectStandardTurret()
    {
        /*Can be called from the UI element. Will communicate with the build manager and currency amount
         *will handle purchasing and other ui aspects*/

        Debug.Log("Standard Turret Selected");
        //choose standard turret
        buildManager.SetTurretToBuild(standardTurret);
    }

    public void SelectAdvancedTurret()
    {
        Debug.Log("Advanced Turret Selected");

        //choose advanced turret
        buildManager.SetTurretToBuild(advancedTurret);
    }
}
