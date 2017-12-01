﻿using UnityEngine;

public class Bullet : MonoBehaviour {

	private Transform target;

	public float speed = 70f;
	public float explosionRadius = 0f;
	public GameObject impactEffect;

	public void Seek(Transform _target) {
		target = _target;
	}

	void Update() {
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}
		transform.Translate (dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt (target);
	}

	void HitTarget() {
		//Debug.Log ("We hit something!");
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy (effectIns, 5f);

		if (explosionRadius > 0) {
			Explode ();
		} else {
			Damage (target);
		}


		Destroy(gameObject);
	}

	void Damage(Transform enemy) {
		Destroy (enemy.gameObject);
	}

	void Explode() {
		Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);
		foreach (Collider collider  in colliders) {
			if (collider.tag == "Enemy") {
				Damage (collider.transform);
			}
		}
	}

	void OnDrawGizmosSelected () {
		Gizmos.color = Color.red; 
		Gizmos.DrawWireSphere (transform.position, explosionRadius);
	}
}
