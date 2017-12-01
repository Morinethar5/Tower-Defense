using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color notEnoughMoneyColor;
	private Color startColor;
	public Vector3 posOffset;

	[Header("Optional")]
	public GameObject turret;

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

		if (!buildManager.CanBuild) {
			return;
		}

		if (turret != null) {
			Debug.Log ("Can't build here! - Todo: display on screen...");
		}

		buildManager.BuildTurretOn (this);
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
