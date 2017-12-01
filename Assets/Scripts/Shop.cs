using UnityEngine;

public class Shop : MonoBehaviour {

	BuildManager buildManager;

	void Start() {
		buildManager = BuildManager.instance;
	}

	public void purchaseStandardTurret() {
		Debug.Log ("Standard Turret Purchased!");
		buildManager.SetTurretToBuild (buildManager.standardTurretPrefab);
	}

	public void purchaseMissileTurret() {
		Debug.Log ("Missile Turret Purchased!");
		buildManager.SetTurretToBuild (buildManager.missileTurretPrefab);
	}

	public void purchaseLaserTurret() {
		Debug.Log ("Laser Turret Purchased!");
		buildManager.SetTurretToBuild (buildManager.laserTurretPrefab);
	}

}
