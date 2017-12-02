using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;

	public float health = 100f;
	public int value = 50;

	public GameObject deathEffect;

	void Start() {
		speed = startSpeed;
	}

	public void TakeDamage (float damage){
		health -= damage;

		if (health <= 0f) {
			Die ();
		}
	}

	public void Slow(float amount) {
		speed = startSpeed * (1f * amount);
	}

	void Die() {
		PlayerStats.Money += value;

		GameObject effect = (GameObject)Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 5f);

		Destroy (gameObject); 
	}
}