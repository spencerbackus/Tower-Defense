using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    { 
        if(instance != null)
        {
            Debug.LogError("another build manager");
        }
        instance = this;
    }


    private TurretBlueprint turretToBuild;
    private Node selectedTurret;
    public TurretUI turretUI;

    //property
    //only allowed to get something from the variable, functionally like checking if turrettobuild is null and returning
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return Stats.money >= turretToBuild.cost; } }


    public void SelectNode(Node node)
    {
        //if the node is equal to the already selected node
        if(selectedTurret == node)
        {
            DeselectTurret();
            return;
        }
        selectedTurret = node;
        turretToBuild = null;
       
    
        turretUI.SetTarget(node);
    }
    public void DeselectTurret()
    {
        selectedTurret = null;
        turretUI.Hide();
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        //change what turret to build
        //use whatever is passed in
        turretToBuild = turret;
        DeselectTurret();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
