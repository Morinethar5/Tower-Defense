using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	private Color startColor;
	public Vector3 posOffset;

	private GameObject turret;

	private Renderer rend;

	BuildManager buildManager;

	void Start() {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;

		buildManager = BuildManager.instance;
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (buildManager.GetTurretToBuild() == null) {
			return;
		}

		if (turret != null) {
			Debug.Log ("Can't build here! - Todo: display on screen...");
		}

		GameObject turretToBuild = buildManager.GetTurretToBuild ();
		turret = (GameObject)Instantiate (turretToBuild, transform.position + posOffset, transform.rotation);
	}

	void OnMouseEnter() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			return;
		}

		if (buildManager.GetTurretToBuild() == null) {
			return;
		}

		rend.material.color = hoverColor;
	}

	void OnMouseExit() {
		rend.material.color = startColor;
	}
}
