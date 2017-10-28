using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipale : MonoBehaviour {

	#region Public
	public GameObject Canvas;
	public GameObject Pannello_Builders;
	[Header("ATTENZIONE PARTE PROVVISORIA")]
	public CanvasGroup[] Group;
	#endregion

	#region Private
	private ManagerAnimations M_Animations;
	private ClusterSwitchButtons M_SwitchButtons;
	private ButtonStyle M_Style;
	private GameObject CurrentMenu;
	private GameObject NextMenu;
	#endregion

	void Awake()
	{

		M_Animations = Canvas.GetComponent<ManagerAnimations> ();
		M_SwitchButtons = Canvas.GetComponent<ClusterSwitchButtons> ();
		M_Style = Canvas.GetComponent<ButtonStyle> ();

	}

	/// <summary>
	/// Funzione che avvia il pannello Builders
	/// </summary>
	public void ManagerPannelloBuilders()
	{

		//Controllo se il pannello è attivo
		if (Pannello_Builders.activeSelf == false && M_SwitchButtons.WhichButtonIsActive("MainMenu").name == "Costruzione") 
		{

			//Attivo l'oggetto
			Pannello_Builders.SetActive (true);
			//Avvio l'animazione di salita 
			M_Animations.GoPattern ("SchermataCostruzione");

		} 
		else if(Pannello_Builders.activeSelf != false)
		{

			//Avvio l'animazione di discesa
			M_Animations.GoPattern ("SchermataCostruzione_back");

		}

	}

	/// <summary>
	/// Metodo provvisorio per il fadeIN
	/// </summary>
	public void FadeInProvvisorio(CanvasGroup Schermata)
	{

		M_Style.FadeIn (Schermata);

		for (int i = 0; i < Group.Length; i++) 
		{

			if (Group [i].gameObject.GetHashCode () != Schermata.gameObject.GetHashCode () && Group [i].alpha > 0) 
			{

				M_Style.FadeOut (Group [i]);

			}

		}


	}

	/// <summary>
	/// Metodo provvisorio per il fadOUT
	/// </summary>
	/// <param name="Schermata">Schermata.</param>
	public void FadeOutProvvisorio()
	{

		for (int i = 0; i < Group.Length; i++) 
		{

			if (Group [i].alpha > 0) 
			{

				M_Style.FadeOut (Group [i]);

			}

		}

	}

	/// <summary>
	/// gestione animazioni di cambio pannello MainMenu
	/// </summary>
	/*public void SwitchPanel()
	{

		//Controlliamo in che pannello siamo 
		CurrentMenu = M_SwitchButtons.WhichButtonIsActive("MainMenu");

		//Controllaimo in che pannello vogliamo andare


		//Avviamo il pattern corretto
		M_Animations.GoPattern("CambioSchermata_2");
		M_Animations.GoPattern ("CambioSchermata");
	}*/

}
