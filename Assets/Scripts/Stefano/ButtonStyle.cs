using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script per la gestione dello stile dei bottoni 
/// </summary>
public class ButtonStyle : MonoBehaviour {

	#region Public
	//Variabile che identifica il testo che appartiene al bottone
	[Header("VARIABILI PER IL GAMEOBJECT CORRENTE")]
	[Header("Testo del bottone")]
	public Text TestoBottone;
	[Header("Colore del bottone")]
	public Color[] ColoreBottone;
	[Header("Colore del testo")]
	public Color[] ColoreTesto;
	[Header("VARIABILI PER UN BOTTONE GENERICO")]
	[Header("Riferimento ad un bottone generico")]
	public Button Bottone_;
	[Header("Testo di un bottone generico")]
	public Text TestoBottone_;
	[Header("Colore del bottone generico")]
	public Color[] ColoreBottone_;
	[Header("Colore del testo generico")]
	public Color[] ColoreTesto_;
	#endregion

	#region Private
	//Reference to button to access its components
	private Button theButton;
	//this get the Transitions of the Button as its pressed
	private ColorBlock theColor;
	#endregion

	// Use this for initialization
	void Awake () 
	{
		theButton = GetComponent<Button>();
		theColor = GetComponent<Button>().colors;

	}

	/// <summary>
	/// Transizione di colore di un bottone passando se attivarlo 
	/// </summary>
	/// <param name="Active">If set to <c>true</c> active.</param>
	public void ButtonTransitionColor(bool Active)
	{

		if (Active == true) 
		{
			//Passare dalla fase disattiva a quella attiva

			theColor.highlightedColor = ColoreBottone[0];
			theColor.normalColor = ColoreBottone[0];
			theColor.pressedColor = ColoreBottone[0];

			TestoBottone.color = ColoreTesto[0];

			theButton.colors = theColor;

			ButtonTransitionColor (Bottone_, TestoBottone_, ColoreBottone_ [1], ColoreTesto_ [1]);

		} 
		else 
		{
			//Passare dalla fase disattiva a quella attiva

			theColor.highlightedColor = ColoreBottone[1];
			theColor.normalColor = ColoreBottone[1];
			theColor.pressedColor = ColoreBottone[1];

			TestoBottone.color = ColoreTesto[1];

			theButton.colors = theColor;

			ButtonTransitionColor (Bottone_, TestoBottone_, ColoreBottone_ [0], ColoreTesto_ [0]);

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

		testo.color = colore_testo;

		bottone.colors = theColor;


	}



}
