using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script per la gestione dello stile dei bottoni 
/// </summary>

[ExecuteInEditMode]
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
	[Header("Colore del bottone Attivo")]
	public Color ColoreBottoneOffDisattivo;
	[Header("Colore del testo Attivo")]
	public Color ColoreTestoOffAttivo;
	[Header("Colore del testo Disattivo")]
	public Color ColoreTestoOffDisattivo;
	[Header("\n\n")]
	[Header("VARIABILI FADE")]
	[Header("Inserire tutti i CanvasGroup dei Menu")]
	public CanvasGroup[] MenuCanvasGroup;
	[Range(0.0f,0.2f)]
	public float TempoFade;
	#endregion

	#region Private
	//this get the Transitions of the Button as its pressed
	private ColorBlock theColor;
	#endregion

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
	/// Fade out di una schermata
	/// </summary>
	/// <param name="schermata">Schermata.</param>
	public void FadeOut()
	{

		CanvasGroup schermata = null;

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
	/// Fade in di una schermata
	/// </summary>
	/// <param name="canvasGroup">Canvas group.</param>
	public void FadeIn(CanvasGroup schermata)
	{

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

		while (canvasGroup.alpha > 0 && IsOut == true) 
		{

			canvasGroup.alpha -= Time.deltaTime / TempoFade;
			yield return null;

		}

		while (canvasGroup.alpha <= 1 && IsOut == false) 
		{

			canvasGroup.alpha += Time.deltaTime / 2;
			yield return null;

		}

		if (IsOut == true) 
		{
			canvasGroup.interactable = false;
			canvasGroup.gameObject.SetActive (false);
			MainMenu.SetActive (true);
		} 
		else 
		{
			canvasGroup.interactable = true;
		}
		
		yield return null;

	}




}
