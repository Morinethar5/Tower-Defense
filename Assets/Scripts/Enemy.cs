﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;

	public float startHealth = 100f;
	private float health;

	public int value = 50;

	public GameObject deathEffect;

	[Header("Unity Stuff")]
	public Image healthBar;

	private bool isDead;

	void Start() {
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage (float damage) {
		health -= damage;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0f && !isDead) {
			Die ();
		}
	}

	public void Slow(float amount) {
		speed = startSpeed * (1f * amount);
	}

	void Die() {
		isDead = true;

		PlayerStats.Money += value;

		GameObject effect = (GameObject)Instantiate (deathEffect, transform.position, Quaternion.identity);
		Destroy (effect, 5f);

		WaveSpawner.EnemiesAlive--;

		Destroy (gameObject); 
	}
}