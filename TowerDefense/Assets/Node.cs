using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    public Vector3 positionOffset;


    BuildManager buildManager;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (turret != null)
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStat.Money < bluePrint.cost)
        {
            return;
        }
        PlayerStat.Money -= bluePrint.cost;
        GameObject _turret = Instantiate(bluePrint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBluePrint = bluePrint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStat.Money < turretBluePrint.upgradeCost)
        {
            return;
        }
        PlayerStat.Money -= turretBluePrint.upgradeCost;

        Destroy(turret);

        GameObject _turret = Instantiate(turretBluePrint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStat.Money += turretBluePrint.GetSellAmount(isUpgraded);

        Destroy(turret);
        turretBluePrint = null;
    }
}
