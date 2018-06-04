using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    private TurretBluePrint turretToBuild;

	
	// Update is called once per frame
	void Update () {
		
	}

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStat.Money < turretToBuild.cost)
        {
            return;
        }
        PlayerStat.Money -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
}
