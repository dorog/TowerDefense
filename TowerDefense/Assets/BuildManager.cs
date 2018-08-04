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

    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    // Update is called once per frame
    void Update () {
		
	}

    public bool CanBuild { get { return turretToBuild != null; } }

    public bool HasMoney { get { return PlayerStat.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
