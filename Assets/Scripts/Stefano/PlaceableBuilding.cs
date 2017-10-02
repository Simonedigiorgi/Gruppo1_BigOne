using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour {

	#region PUBLIC
	[HideInInspector]
	public List<Collider> colliders = new List<Collider> ();
	#endregion

	#region PRIVATE
	private bool isSelected;
	#endregion

	/// <summary>
	/// Controllo se un oggetto è entrato dal trigger della struttura
	/// </summary>
	/// <param name="other">Oggetto entrato nel trigger</param>
	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Building") {

			colliders.Add (other);

		}

	}

	/// <summary>
	/// Controllo se un oggetto è uscito dal trigger della struttura
	/// </summary>
	/// <param name="other">Oggetto uscito dal trigger</param>
	void OnTriggerExit(Collider other)
	{

		if (other.tag == "Building") {

			colliders.Remove (other);

		}

	}

	/// <summary>
	/// Controllo se la struttura è selezionata
	/// </summary>
	/// <param name="selected">If set to <c>true</c> selected.</param>
	public void SetSelected(bool selected)
	{

		isSelected = selected;

	}
		
}
