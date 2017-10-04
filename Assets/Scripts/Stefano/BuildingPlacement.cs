﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlacement : MonoBehaviour {

	#region PUBLIC
	public float ScrollSensitivity;
	public GameObject Pannello_Opzioni;
	public GameObject Pannello_Decisionale;
	#endregion

	#region PRIVATE
	private PlaceableBuilding placeableBuilding;
	private PlaceableBuilding placeablebuildingOld;
	private Transform currentBuilding;
	private bool hasPlaced;
	private Vector3 p;
	private GameObject Oggetto_Selezionato;
	#endregion

	#region OTHER
	public LayerMask BuildingMask;
	#endregion
	
	// Update is called once per frame
	void Update () 
	{

		Vector3 m = Input.mousePosition;
		m = new Vector3 (m.x, m.y, transform.position.y);

		p = Camera.main.ScreenToWorldPoint (m); 
		//Vector3 p = new Vector3(0,0,0);

		if (currentBuilding != null && !hasPlaced) {

			currentBuilding.position = new Vector3 (p.x, 0, p.z);
			if (Input.GetMouseButton (0)) {

				if (IsLegalPosition () && placeableBuilding.GetCorrectLocation()) 
				{

					hasPlaced = true;
					Pannello_Decisionale.SetActive (true);

				}

			}

		} else {

			if (Input.GetMouseButtonDown (0)) {

				RaycastHit hit = new RaycastHit ();
				Ray ray = new Ray (new Vector3 (p.x, 8, p.z), Vector3.down);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, BuildingMask)) {

					Pannello_Opzioni.SetActive (true);

					hit.collider.gameObject.GetComponent<PlaceableBuilding> ().SetSelected (true);
					placeablebuildingOld = hit.collider.gameObject.GetComponent<PlaceableBuilding> ();

				} else {

					if (placeableBuilding != null) {

						placeableBuilding.SetSelected (false);

						Pannello_Opzioni.SetActive (false);

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

	/// <summary>
	/// Metodo per decidere se piazzare un edificio
	/// </summary>
	/// <param name="decisione">If set to <c>true</c> decisione.</param>
	public void Piazzare(bool decisione)
	{

		hasPlaced = decisione;

		if (hasPlaced == false) {

			//Lo distruggiamo in caso di risposta negativa
			Destroy (currentBuilding.gameObject);

		} else {

			//Tutto bene 
			Debug.Log ("Edificio piazzato con successo");

		}

		Pannello_Decisionale.SetActive (false);

	}

}