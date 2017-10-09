using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableBuilding : MonoBehaviour {

	#region PUBLIC
	[HideInInspector]
	public List<Collider> colliders = new List<Collider> ();
	[Header("Lista materiali")]
	public Material[] material;
	#endregion

	#region PRIVATE
	private bool isSelected;
	private bool CorrectLocation;
	private Renderer rend;
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

		if (other.tag == "Place") 
		{
			rend = other.gameObject.GetComponent<Renderer> ();
			rend.enabled = true;
			rend.sharedMaterial = material [0];

			Renderer[] renderers = GetComponentsInChildren<Renderer> ();

			foreach(var r in renderers)
			{

				r.enabled = true;
				r.sharedMaterial = material [0];
			}

			CorrectLocation = true;

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

		if (other.tag == "Place") 
		{
			rend = other.gameObject.GetComponent<Renderer> ();
			rend.enabled = true;
			rend.sharedMaterial = material [1];

			Renderer[] renderers = GetComponentsInChildren<Renderer> ();

			foreach(var r in renderers)
			{

				r.enabled = true;
				r.sharedMaterial = material [1];
			}

		}

		CorrectLocation = false;

	}

	/// <summary>
	/// Controllo se la struttura è selezionata
	/// </summary>
	/// <param name="selected">If set to <c>true</c> selected.</param>
	public void SetSelected(bool selected)
	{

		isSelected = selected;

	}

	public bool GetCorrectLocation()
	{

		return CorrectLocation;

	}
		
}
