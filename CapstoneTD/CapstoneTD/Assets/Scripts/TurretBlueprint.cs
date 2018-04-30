using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Unity will save and load the values inside of this class for us, they will be visible in the inspector
//and we can edit them
[System.Serializable]
public class TurretBlueprint {

    //for tower upgrade information
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

}
