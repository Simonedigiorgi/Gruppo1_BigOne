using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchButtton : MonoBehaviour {

	#region Public
	public List<Cluster> ListaCluster;
	#endregion

	#region Private
	private ColorBlock theColor;
	#endregion

	[System.Serializable]
	public class Cluster
	{
		
		[Header("Bottoni")]
		public Button[] Bottoni;

		[Header("Colore bottone attivo")]
		public Color BottoneAttivo;
		[Header("Colore Immagini attive")]
		public Color ImmaginiAttive;
		[Header("Colore Testi attivi")]
		public Color TestiAttivi;

		[Header("Colore bottone disattivo")]
		public Color BottoneDisattivato;
		[Header("Colore Immagini disattive")]
		public Color ImmaginiDisattive;
		[Header("Colore Testi disattivi")]
		public Color TestiDisattivi;

		[Header("Cambiare colore delle immagini figlie?")]
		public bool Immagini;
		[Header("Cambiare colore dei testi figli?")]
		public bool Testi;
		[Header("Disabilitare il bottone On?")]
		public bool DisabilitareOn;

	}

	#region Button
	/// <summary>
	/// Identifico il bottone On e lo attivo e disattivo tutti gli altri
	/// </summary>
	/// <param name="On">On.</param>
	public void SwitchButtonNow(Button On)
	{

		for (int i = 0; i < ListaCluster.Count; i++) 
		{

			for (int j = 0; j < ListaCluster [i].Bottoni.Length; j++) 
			{

				if (ListaCluster [i].Bottoni [j].GetHashCode () == On.GetHashCode ()) 
				{

					//Assegno il colore al bottone On
					theColor.highlightedColor = ListaCluster [i].BottoneAttivo;
					theColor.normalColor = ListaCluster [i].BottoneAttivo;
					theColor.pressedColor = ListaCluster [i].BottoneAttivo;
					theColor.disabledColor = ListaCluster [i].BottoneAttivo;
					theColor.colorMultiplier = 1;

					ListaCluster [i].Bottoni [j].colors = theColor;

					//Cerco tutti i figli del bottone e gli cambio il colore
					for (int t = 0; t < ListaCluster [i].Bottoni [j].transform.childCount; t++) 
					{


						if (ListaCluster [i].Bottoni [j].transform.GetChild (t).gameObject.GetHashCode () != On.gameObject.GetHashCode ()) 
						{

							//Per semplificare la scrittura del codice assegno ad un oggetto l'oggetto della lista
							GameObject obj = ListaCluster [i].Bottoni [j].transform.GetChild (t).gameObject;

							if (obj.GetComponent<Image> () != null && ListaCluster [i].Immagini == true) {

								obj.GetComponent<Image> ().color = ListaCluster [i].ImmaginiAttive;

							}

							if (obj.GetComponent<Text> () != null && ListaCluster [i].Testi == true) {

								obj.GetComponent<Text> ().color = ListaCluster [i].TestiAttivi;

							}

							if (ListaCluster [i].DisabilitareOn == true) {


								On.interactable = false;

							}


						}

					}


				} 
				else 
				{

					//Assegno il colore al bottone Off
					theColor.highlightedColor = ListaCluster [i].BottoneDisattivato;
					theColor.normalColor = ListaCluster [i].BottoneDisattivato;
					theColor.pressedColor = ListaCluster [i].BottoneDisattivato;
					theColor.disabledColor = ListaCluster [i].BottoneDisattivato;
					theColor.colorMultiplier = 1;

					ListaCluster [i].Bottoni [j].colors = theColor;

					ListaCluster [i].Bottoni [j].interactable = true;

					for (int t = 0; t < ListaCluster [i].Bottoni [j].transform.childCount; t++) {

						if (ListaCluster [i].Bottoni [j].transform.GetChild (t).gameObject.GetHashCode () != ListaCluster [i].Bottoni [j].gameObject.GetHashCode()) {

							//Per semplificare la scrittura del codice assegno ad un oggetto l'oggetto della lista
							GameObject obj = ListaCluster [i].Bottoni [j].transform.GetChild (t).gameObject;

							if (obj.GetComponent<Image> () != null && ListaCluster [i].Immagini == true) {

								obj.GetComponent<Image> ().color = ListaCluster [i].ImmaginiDisattive;

							}

							if (obj.GetComponent<Text> () != null && ListaCluster [i].Testi == true) {

								obj.GetComponent<Text> ().color = ListaCluster [i].TestiDisattivi;

							}


						}

					}



				}

			}


		}

	}
	#endregion 

}
