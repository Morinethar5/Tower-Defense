﻿using UnityEngine;

public class Node : MonoBehaviour {

	public Color hoverColor;
	private Color startColor;

	private GameObject turret;

	private Renderer rend;

	void Start() {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseDown() {
		if (turret != null) {
			Debug.Log ("Can't build here! - Todo: display on screen...");
		}
	}

	void OnMouseEnter() {
		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}