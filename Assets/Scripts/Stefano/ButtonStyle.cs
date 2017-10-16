﻿using System.Collections;
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
	#endregion

	#region Private
	//this get the Transitions of the Button as its pressed
	private ColorBlock theColor;
	private bool BackMainMenu;
	#endregion

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

	public void ResetAnimator(Animator anim)
	{

		anim.speed = 1;

	}

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

	public void test()
	{


		ListaAnimazioni [0].anim.speed = ListaAnimazioni [0].speed;


	}

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




}
