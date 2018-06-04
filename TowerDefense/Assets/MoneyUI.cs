using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    private Text MoneyText;

	// Use this for initialization
	void Start () {
        MoneyText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        MoneyText.text = "$"+PlayerStat.Money;
	}
}
