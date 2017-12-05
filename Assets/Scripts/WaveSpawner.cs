using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private int waveIndex = 0;

	public Text waveCountdownText;

	public GameManager gameManager;

	public Transform spawnPoint;

	void Update() {
		if (waveIndex == waves.Length) {
			this.enabled = false;
			//Load next level...
			gameManager.WinLevel();
		}

		if (EnemiesAlive > 0) {
			return;
		}

		if (countdown <= 0) {
			StartCoroutine(SpawnWave ());
			countdown = timeBetweenWaves;
			return;
		}
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.0}", countdown);
	}

	IEnumerator SpawnWave() {
		//Debug.Log ("Wave coming!");
		PlayerStats.Rounds++;

		Wave wave = waves [waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++) {
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy(GameObject enemy) {
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
	}
}