﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public SceneFader sceneFader;
	public string menuSceneName = "_MainMenu";

	public void Retry() {
		//SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		sceneFader.FadeTo (SceneManager.GetActiveScene ().name);
	}

	public void Menu() {
		sceneFader.FadeTo (menuSceneName);
	}
}