using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;

    public Button[] levelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = levelReached; i < levelButtons.Length + 1; i++)
        {
            levelButtons[i].interactable = false;
        }
    }

    public void LevelSelect(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
