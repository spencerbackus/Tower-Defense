using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    { 
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }


    public GameObject advancedTurretPrefab;
    public GameObject standardTurretPrefab;

    private TurretBlueprint turretToBuild;

    //property
    //only allowed to get something from the variable, functionally like checking if turrettobuild is null and returning
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Stats.money >= turretToBuild.cost; } }


    public void BuildTurretOn(Node node)
    {
        if (Stats.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        Stats.money -= turretToBuild.cost; //subtract money when purchasing
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;  

    }


    public void SetTurretToBuild(TurretBlueprint turret)
    {
        //change what turret to build
        //use whatever is passed in
        turretToBuild = turret;
    }

}
