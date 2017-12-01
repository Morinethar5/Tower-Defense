﻿using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;


	void Awake() {
		if (instance != null) {
			Debug.LogError ("More than one instance of BuildManager in scene!");
			return;
		}
		instance = this;
	}

	private GameObject turretToBuild;

	public GameObject standardTurretPrefab;
	public GameObject missileTurretPrefab;
	public GameObject laserTurretPrefab;

	public GameObject GetTurretToBuild() {
		return turretToBuild;
	}

	public void SetTurretToBuild(GameObject turret) {
		turretToBuild = turret;
	}

}
