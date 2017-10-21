using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script per la gestione dello stile dei bottoni 
/// </summary>

[HelpURL("https://docs.google.com/document/d/12-VXr47s9CWktrHoCkdmX8AIy5X2lLYSbZgAqpWsnDU/edit")]
public class ButtonStyle : MonoBehaviour {

	#region Public
	[Header("IDENTIFICARE IL MAIN MENU")]
	public GameObject MainMenu;
	[Header("\n\n")]
	[Header("FUNZIONE ON/OFF BOTTONI")]
	[Header("Inserire i parametri del primo bottone ON")]
	[Header("Colore del bottone Attivo")]
	public Color ColoreBottoneOnAttivo;
	[Header("Colore del bottone Disattivo")]
	public Color ColoreBottoneOnDisattivo;
	[Header("Colore del testo Attivo")]
	public Color ColoreTestoOnAttivo;
	[Header("Colore del testo Disattivo")]
	public Color ColoreTestoOnDisattivo;
	[Header("\n\n")]
	[Header("Inserire i parametri del secondo bottone OFF")]
	[Header("Colore del bottone Attivo")]
	public Color ColoreBottoneOffAttivo;
	[Header("Colore del bottone Disattivo")]
	public Color ColoreBottoneOffDisattivo;
	[Header("Colore del testo Attivo")]
	public Color ColoreTestoOffAttivo;
	[Header("Colore del testo Disattivo")]
	public Color ColoreTestoOffDisattivo;
	[Header("\n\n")]
	[Header("VARIABILI FADE")]
	[Header("Inserire tutti i CanvasGroup dei Menu")]
	public CanvasGroup[] MenuCanvasGroup;
	[Range(0.0f,2f)]
	public float TempoFadeOut;
	[Range(0.0f,2f)]
	public float TempoFadeIn;
	[Header("\n\n")]
	[Header("SISTEMA ANIMAZONI")]
	[Header("Lista animazioni UI")]
	public List<ListAnimazioni> ListaAnimazioni;
	[Header("\n\n")]
	[Header("SISTEMA GESTIONE CAMERE")]
	[Header("Identificare MainCamera")]
	public Camera Main_Camera;
	[Header("Vettore di camere")]
	public Camera[] Camere;
	#endregion

	#region Private
	//this get the Transitions of the Button as its pressed
	private ColorBlock theColor;
	private bool BackMainMenu;
	private int index_camere = 0;
	#endregion

	#region Animation
	[System.Serializable]
	public class ListAnimazioni
	{
		[Header("Animation della clip")]
		public Animator anim;
		[Header("\n\n")]
		[Header("PUOI INSERIRE LA CLIP OPPURE IL NOME DELLA STESSA ANIMAZIONE")]
		[Header("Animazione schermata")]
		public AnimationClip animazione;
		[Header("Nome animazione schermata")]
		public string nome_animazione;
		[Header("\n\n")]
		[Header("Velocità animazione")]
		[Range(0.1f,2.0f)]
		public float speed;

	}

	/// <summary>
	/// Esegue l'animazione passando la stringa del nome dell'animazione dello state dell'animator
	/// </summary>
	/// <param name="NomeAnimazione">Nome animazione.</param>
	public void GoAnimation(string NomeAnimazione)
	{

		int index = SearchListAnimation (NomeAnimazione);

		if (index >= 0) 
		{

			//Resettiamo l'animator prima di modificarlo //CONTROLLO AGGIUNTIVO
			ResetAnimator (ListaAnimazioni[index].anim);
			//modifico la velocità dell'animator
			ListaAnimazioni [index].anim.speed = ListaAnimazioni [index].speed;
			//Avvio animazione
			ListaAnimazioni [index].anim.Play (NomeAnimazione);

		}



	}


	/// <summary>
	/// Esegue l'animaizone passando la clip da eseguire
	/// </summary>
	/// <param name="Animazione">Animazione.</param>
	public void GoAnimation(AnimationClip Animazione)
	{

		int index = SearchListAnimation (Animazione.name);

		if (index >= 0) 
		{

			//Resettiamo l'animator prima di modificarlo //CONTROLLO AGGIUNTIVO
			ResetAnimator (ListaAnimazioni[index].anim);
			//modifico la velocità dell'animator
			ListaAnimazioni [index].anim.speed = ListaAnimazioni [index].speed;
			//Avvio animazione
			ListaAnimazioni [index].anim.Play (Animazione.name);

		}

	}

	/// <summary>
	/// Metodon che resetta le impostazioni dell'animator a default
	/// </summary>
	/// <param name="anim">Animation.</param>
	public void ResetAnimator(Animator anim)
	{

		anim.speed = 1;

	}

	/// <summary>
	/// Metoodo che permette di ricercare un'animazione all'interno della lista passando una stringa
	/// </summary>
	/// <returns>The list animation.</returns>
	/// <param name="Target">Target.</param>
	private int SearchListAnimation(string Target)
	{


		for (int i = 0; i < ListaAnimazioni.Count; i++) 
		{

			//ricerca tramite animazione
			if (ListaAnimazioni [i].animazione != null) 
			{

				if (ListaAnimazioni [i].animazione.name == Target) 
				{


					return i;

				} 

			}
			else //Ricerca tramite stringa
			{

				if (ListaAnimazioni [i].nome_animazione == Target) 
				{


					return i;

				}

			}



		}

		Debug.Log ("Animazione non nella lista");

		return -1;

	}
	#endregion	

	#region Button
	/// <summary>
	/// Metodo per identificare il bottone On 
	/// </summary>
	/// <returns>The button on.</returns>
	/// <param name="On">On.</param>
	private Button BottoneOn; 
	public void IdentifyButtonOn(Button On)
	{
		BottoneOn = On;

	}

	/// <summary>
	/// Metodo per identificare il bottone Off
	/// </summary>
	/// <returns>The button off.</returns>
	/// <param name="Off">Off.</param>
	private Button BottoneOff;
	public void IdentifyButtonOff(Button Off)
	{

		BottoneOff = Off;

	}

	/// <summary>
	/// Transizione di colore di una coppia di bottoni On/Off
	/// </summary>
	/// <param name="Active">If set to <c>true</c> active.</param>
	public void ButtonTransitionColor(bool Active)
	{

		Text TestoBottoneOn = BottoneOn.GetComponentInChildren<Text> ();
		Text TestoBottoneOff = BottoneOff.GetComponentInChildren<Text>();

		if (Active == true) 
		{
			//Passare dalla fase disattiva a quella attivo

			ButtonTransitionColor (BottoneOn, TestoBottoneOn, ColoreBottoneOnAttivo, ColoreTestoOnAttivo);
			ButtonTransitionColor (BottoneOff, TestoBottoneOff, ColoreBottoneOffDisattivo, ColoreTestoOffDisattivo);

		} 
		else 
		{
			//Passare dalla fase disattiva a quella attiva


			ButtonTransitionColor (BottoneOn, TestoBottoneOn, ColoreBottoneOnDisattivo, ColoreTestoOnDisattivo);
				ButtonTransitionColor (BottoneOff, TestoBottoneOff, ColoreBottoneOffAttivo, ColoreTestoOffAttivo);

		}

	}

	/// <summary>
	/// Transizione di colore di un bottone passando un bottone ed il Colore
	/// </summary>
	/// <param name="bottone">Bottone.</param>
    public void ButtonTransitionColor(Button bottone, Text testo ,Color colore_bottone, Color colore_testo )
	{


		theColor.highlightedColor = colore_bottone;
		theColor.normalColor = colore_bottone;
		theColor.pressedColor = colore_bottone;
		theColor.disabledColor = colore_bottone;

		theColor.colorMultiplier = 1;

		testo.color = colore_testo;

		bottone.colors = theColor;


	}
	#endregion 

	#region Fade
	/// <summary>
	/// Fade out della schermata corrente verso il MainMenu
	/// </summary>
	/// <param name="schermata">Schermata.</param>
	public void FadeOut()
	{

		CanvasGroup schermata = null;
		BackMainMenu = true;

		try
		{
			//cerco la schermata attiva
			for (int i = 0; i < MenuCanvasGroup.Length - 1; i++) 
			{

				if (MenuCanvasGroup [i].gameObject.activeSelf == true) 
				{

					schermata = MenuCanvasGroup [i];

				}

			}

			Debug.Log(schermata.gameObject.name+(" fade out"));
			StartCoroutine (DoFade (schermata, true));
		} 
		catch
		{

			Debug.Log("Errore nel Fade Out");

		}

	}

	/// <summary>
	/// Fades the out di una schermata generica
	/// </summary>
	/// <param name="schermata">Schermata.</param>
	public void FadeOut(CanvasGroup schermata)
	{

		BackMainMenu = false;

		Debug.Log(schermata.gameObject.name+(" fade out"));
		StartCoroutine (DoFade (schermata, true));

	}

	/// <summary>
	/// Fade in di una schermata
	/// </summary>
	/// <param name="canvasGroup">Canvas group.</param>
	public void FadeIn(CanvasGroup schermata)
	{

		schermata.gameObject.SetActive (true);

		Debug.Log(schermata.gameObject.name+(" fade in"));
		StartCoroutine (DoFade (schermata, false));

	}

	/// <summary>
	/// Coroutine per il fade delle schermate
	/// </summary>
	/// <returns>The fade out.</returns>
	/// <param name="canvasGroup">Canvas group.</param>
	/// <param name="IsOut">If set to <c>true</c> is out.</param>
	IEnumerator DoFade(CanvasGroup canvasGroup, bool IsOut)
	{

		//FadeOut 
		while (canvasGroup.alpha > 0 && IsOut == true) 
		{

			canvasGroup.alpha -= Time.deltaTime / TempoFadeOut;
			yield return null;

		}

		//FadeIn
		while (canvasGroup.alpha < 1 && IsOut == false) 
		{

			canvasGroup.alpha += Time.deltaTime / TempoFadeIn;
			Debug.Log (canvasGroup.alpha);
			yield return null;

		}
			

		if (IsOut == true && BackMainMenu == true) 
		{

			Debug.Log ("Avvio FadeIn Main");

			canvasGroup.interactable = false;
			canvasGroup.gameObject.SetActive (false);
			MainMenu.SetActive (true);

			CanvasGroup MainCanvasGroup = MainMenu.GetComponent<CanvasGroup> ();
			MainCanvasGroup.interactable = true;

			while (MainCanvasGroup.alpha < 1) 
			{

				MainCanvasGroup.alpha += Time.deltaTime / TempoFadeIn;
				yield return null;

			}

		} 
		else if (IsOut == true && BackMainMenu == false) {

			canvasGroup.interactable = false;
			canvasGroup.gameObject.SetActive (false);

		}
		else 
		{
			canvasGroup.interactable = true;
		}
		
		yield return null;

	}
	#endregion

	#region Camera
	/// <summary>
	/// Cambiare camera scorrendo il vettore
	/// </summary>
	public void ChangeCameraSequanzial()
	{
		if (index_camere == 0) 
		{

			Main_Camera.enabled = false;

		} else if (index_camere >= Camere.Length) 
		{

			index_camere = 0;

		}

		Camere [index_camere].enabled = true;
		//Camere [index_camere].cameraType 
		index_camere++;



	}

	/// <summary>
	/// Metodo che fa ritornare il controllo alla Main Camera
	/// </summary>
	public void ReturnToMainCamera()
	{

		Main_Camera.enabled = true;
		DisableAllCamere ();

	}


	/// <summary>
	/// Disabilita tutte le camere del vettore
	/// </summary>
	public void DisableAllCamere()
	{

		foreach(Camera cam in Camere)
		{

			cam.enabled = false;

		}

		//Resettiamo l'indicie delle camere 
		index_camere = 0;

	}

	/// <summary>
	/// Permette di andare ad una camera specifica passando una Camera
	/// </summary>
	/// <param name="cam">Cam.</param>
	public void GoToSpecificCamera(Camera cam)
	{

		DisableAllCamere ();
		Main_Camera.enabled = false;
		cam.enabled = true;

	}
	#endregion

}
