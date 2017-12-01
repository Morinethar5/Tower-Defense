﻿using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;

	public TurretBlueprint standardTurret;
	public TurretBlueprint missileLauncher;
	public TurretBlueprint laserTurret;

	void Start() {
		buildManager = BuildManager.instance;
	}

	public void selectStandardTurret() {
//		Debug.Log ("Standard Turret Purchased!");
//		buildManager.SetTurretToBuild (buildManager.standardTurretPrefab);
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void selectMissileTurret() {
//		Debug.Log ("Missile Turret Purchased!");
//		buildManager.SetTurretToBuild (buildManager.missileTurretPrefab);
		buildManager.SelectTurretToBuild(missileLauncher);
	}

	public void selectLaserTurret() {
//		Debug.Log ("Laser Turret Purchased!");
//		buildManager.SetTurretToBuild (buildManager.laserTurretPrefab);
		buildManager.SelectTurretToBuild(laserTurret);
	}

}
