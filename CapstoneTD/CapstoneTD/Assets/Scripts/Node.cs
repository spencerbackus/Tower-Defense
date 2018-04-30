using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color noMoneyColor;
    public Vector3 positionOffset;

    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown()
    {
        //if hovering over node
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if(turret != null)
        {
            buildManager.SelectNode(this); //if you click on something already placed it will select it.
            return;
        }

        //don't want to build null
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (Stats.money < blueprint.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        Stats.money -= blueprint.cost; //subtract money when purchasing
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
    }
    
    public void UpgradeTurret()
    {
        if (Stats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade!");
            return;
        }

        Stats.money -= turretBlueprint.upgradeCost; //subtract money when purchasing
        
        Destroy(turret);

        //build new turret

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        isUpgraded = true;
        
    }
    void OnMouseEnter()
    {
        //if hovering over node
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //only highlight when we have a turret to build
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = noMoneyColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
