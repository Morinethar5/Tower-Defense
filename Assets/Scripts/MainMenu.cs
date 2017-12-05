using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string levelToLoad = "_Level01";

	public SceneFader sceneFader;

	public void Play() {
		//Debug.Log ("Play");
		sceneFader.FadeTo(levelToLoad);
	}

	public void Quit() {
		Debug.Log ("Exiting game...");
		Application.Quit ();
	}
}