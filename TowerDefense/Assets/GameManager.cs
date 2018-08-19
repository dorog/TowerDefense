using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;

    public string nextLevel = "Level02";
    public int levelUnlock = 2;
    public SceneFader sceneFader;

    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update () {
        if (GameIsOver)
            return;

		if(PlayerStat.Lives  <= 0)
        {
            EndGame();
        }
	}

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        PlayerPrefs.SetInt("levelReached", levelUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
