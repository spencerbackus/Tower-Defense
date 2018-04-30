using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour {

    public Text upgradeCost;
    public GameObject ui;
    public Button upgradeButton;
    private Node target;
    public void SetTarget(Node target)
    {
        //set the target and move the ui
        this.target = target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded) {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        //hide the upgrade/sell menu in case multiple turrets near each other
        ui.SetActive(false);
        
    }

    public void Upgrade()
    {   //function to upgrade turret
        target.UpgradeTurret();

        //To close the popup when you click on the turret and deselect the turret
        BuildManager.instance.DeselectTurret();
    }
}
