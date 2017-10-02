using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour {

	#region PUBLIC
	[Header("Vettore di oggetti costruibili")]
	public GameObject[] buildings;
	#endregion

	#region PRIVATE
	private BuildingPlacement buildingsPlacement;
	#endregion

	// Use this for initialization
	void Start () {

		buildingsPlacement = GetComponent<BuildingPlacement> ();
	}

}
