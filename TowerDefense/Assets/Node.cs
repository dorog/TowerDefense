using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    [Header("Optional")]
    public GameObject turret;

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
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;
        if(turret != null)
        {
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (turret != null)
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
}
