using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private int waveIndex = 0;

	public Text waveCountdownText;

	public Transform spawnPoint;

	void Update() {
		if (countdown <= 0) {
			StartCoroutine(SpawnWave ());
			countdown = timeBetweenWaves;
		}
		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp (countdown, 0, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.0}", countdown);
	}

	IEnumerator SpawnWave() {
		//Debug.Log ("Wave coming!");
		waveIndex++;
		PlayerStats.Rounds++;

		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy() {
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}