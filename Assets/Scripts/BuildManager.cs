using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;


	void Awake() {
		if (instance != null) {
			Debug.LogError ("More than one instance of BuildManager in scene!");
			return;
		}
		instance = this;
	}

	private TurretBlueprint turretToBuild;

	public GameObject standardTurretPrefab;
	public GameObject missileTurretPrefab;
	public GameObject laserTurretPrefab;

	public GameObject buildEffect;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

//	public GameObject GetTurretToBuild() {
//		return turretToBuild;
//	}

	public void SelectTurretToBuild(TurretBlueprint turret) {
		turretToBuild = turret;
	}

	public void BuildTurretOn(Node node) {
		if (PlayerStats.Money < turretToBuild.cost) {
			Debug.Log ("Not enough money to buy this turret!");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		Debug.Log ("Turret built, money left: " + PlayerStats.Money);

		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, node.GetBuildPosition (), Quaternion.identity);
		node.turret = turret;

		GameObject effect = (GameObject)Instantiate (buildEffect, node.GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);
	}

}
