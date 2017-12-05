using UnityEngine;

public class GameManager : MonoBehaviour {

	public static bool gameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start() {
		gameIsOver = false;
	}

	void Update() {
		if (gameIsOver) {
			return;
		}

		if (PlayerStats.Lives <= 0) {
			EndGame ();
		}
	}

	private void EndGame() {
		gameIsOver = true;
		Debug.Log ("GAME OVER!");

		gameOverUI.SetActive (true);
	}

	public void WinLevel() {
		gameIsOver = true;
		completeLevelUI.SetActive (true);

	}
}