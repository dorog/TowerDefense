using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;

    BuildManager buildManager;

	// Use this for initialization
	void Start () {
        buildManager = BuildManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLaunche()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }
}
