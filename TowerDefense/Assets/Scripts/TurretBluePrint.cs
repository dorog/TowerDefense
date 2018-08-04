using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBluePrint {

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount(bool upgraded)
    {
        return upgraded ?  (cost /2 + upgradeCost / 2) : (cost / 2);
    }
}
