using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour {

	#region PUBLIC
	public float ScrollSensitivity;
	#endregion

	#region PRIVATE
	private PlaceableBuilding placeableBuilding;
	private PlaceableBuilding placeablebuildingOld;
	private Transform currentBuilding;
	private bool hasPlaced;
	#endregion

	#region OTHER
	public LayerMask BuildingMask;
	#endregion

	
	// Update is called once per frame
	void Update () {

		Vector3 m = Input.mousePosition;
		m = new Vector3 (m.x, m.y, transform.position.y);

		//Vector3 p = Camera.ScreenToWorldPoint (m); ----> da capire l'errore
		Vector3 p = new Vector3(0,0,0);

		if (currentBuilding != null && !hasPlaced) {

			currentBuilding.position = new Vector3 (p.x, 0, p.z);
			if (Input.GetMouseButton (0)) {

				if (IsLegalPosition ()) {

					hasPlaced = true;

				}

			}

		} else {

			if (Input.GetMouseButtonDown (0)) {

				RaycastHit hit = new RaycastHit ();
				Ray ray = new Ray (new Vector3 (p.x, 8, p.z), Vector3.down);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, BuildingMask)) {

					hit.collider.gameObject.GetComponent<PlaceableBuilding> ().SetSelected (true);
					placeablebuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding> ();

				} else {

					if (placeableBuilding != null) {

						placeableBuilding.SetSelected (false);

					}

				}

			}

		}

	}

	/// <summary>
	/// Determines whether this instance is legal position.
	/// </summary>
	/// <returns><c>true</c> if this instance is legal position; otherwise, <c>false</c>.</returns>
	private bool IsLegalPosition()
	{

		if (placeableBuilding.colliders.Count > 0) {

			return false;

		} else {

			return true;

		}

	}

	/// <summary>
	/// Sets the item.
	/// </summary>
	/// <param name="obj">Object.</param>
	public void SetItem(GameObject obj)
	{

		hasPlaced = false;
		currentBuilding = ((GameObject)Instantiate (obj)).transform;
		placeableBuilding = currentBuilding.GetComponent<PlaceableBuilding> ();

	}
}
