using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

	public SceneFader sceneFader;
	public string menuSceneName = "_MainMenu";

	public string nextLevel = "_Level02";
	public int levelToUnlock = 2;

	public void Continue() {
		PlayerPrefs.SetInt("levelReached", levelToUnlock);
		sceneFader.FadeTo (nextLevel);
	}

	public void Menu() {
		sceneFader.FadeTo (menuSceneName);
	}
}