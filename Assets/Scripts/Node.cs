using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
	private Color startColor;
	public Vector3 posOffset;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;

	BuildManager buildManager;

	void Start() {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition() {
		return transform.position + posOffset;
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (turret != null) {
			//Debug.Log ("Can't build here! - Todo: display on screen...");
			buildManager.SelectedNodeToBuild(this);
			return;
		}

		if (!buildManager.CanBuild) {
			return;
		}

		BuildTurret (buildManager.GetTurretToBuild());
	}

	void BuildTurret (TurretBlueprint blueprint) {
		if (PlayerStats.Money < blueprint.cost) {
			Debug.Log ("Not enough money to buy this turret!");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject _turret = (GameObject)Instantiate (blueprint.prefab, GetBuildPosition (), Quaternion.identity);
		turret = _turret;

		turretBlueprint = blueprint;

		GameObject effect = (GameObject)Instantiate (buildManager.buildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		Debug.Log ("Turret built!");
	}

	public void UpgradeTurret() {
		if (PlayerStats.Money < turretBlueprint.upgradeCost) {
			Debug.Log ("Not enough money to upgrade this turret!");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//Get rid of the old version of the turret.
		Destroy(turret);

		//Building new upgraded turret
		GameObject _turret = (GameObject)Instantiate (turretBlueprint.upgradedPrefab, GetBuildPosition (), Quaternion.identity);
		turret = _turret;

		GameObject effect = (GameObject)Instantiate (buildManager.buildEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		isUpgraded = true;

		Debug.Log ("Turret upgraded!");
	}

	public void SellTurret() {
		PlayerStats.Money += turretBlueprint.GetSellAmount();

		GameObject effect = (GameObject)Instantiate (buildManager.sellEffect, GetBuildPosition (), Quaternion.identity);
		Destroy (effect, 5f);

		Destroy (turret);
		turretBlueprint = null;
	}

	void OnMouseEnter() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (!buildManager.CanBuild) {
			return;
		}

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else {
			rend.material.color = notEnoughMoneyColor;
		}
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}
