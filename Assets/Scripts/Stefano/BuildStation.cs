using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script che si occupa della creazione dei moduli
/// </summary>
public class BuildStation : MonoBehaviour {

	#region Public
	[Header("Lista Moduli")]
	public List<Modulo> Moduli;
	[Header("Lista materiali")]
	public Material[] material;
	#endregion

	[System.Serializable]
	public class Modulo
	{

		public GameObject Edificio;
		public GameObject Posizionamento;

	}
		
	/// <summary>
	/// Posizioniamo il modulo in una data posizone
	/// </summary>
	/// <param name="index">Indice del vettore dei moduli</param>
	public void CostruisciModulo(int index)
	{

        //Instantiate (Moduli [index].Edificio, Moduli [index].Posizionamento.transform.position, Quaternion.identity);
        Moduli[index].Edificio.SetActive(true);
        Moduli[index].Posizionamento.GetComponent<Activity>().currentState = Activity.State.ENABLED;

        Debug.Log ("Creata stazione");

	}

	/// <summary>
	/// Metodo che cambia colore al modulo quando viene costruito
	/// </summary>
	public void CambioColoreEdificio(int index)
	{
		//Renderer rend;

		/*rend = Moduli [index].Edificio.gameObject.GetComponent<Renderer> ();
		rend.enabled = true;
		rend.sharedMaterial = material [0];*/

		Renderer[] renderers = Moduli [index].Edificio.gameObject.GetComponentsInChildren<Renderer> ();

		foreach(var r in renderers)
		{

			r.enabled = true;
			r.sharedMaterial = material [0];
			Debug.Log ("Color il componente");
		}

	}

}
