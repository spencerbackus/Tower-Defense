using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color noMoneyColor;
    public Vector3 positionOffset;

    public GameObject turret;

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

        //don't want to build null
        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        buildManager.BuildTurretOn(this);

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
