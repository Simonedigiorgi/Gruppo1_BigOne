using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelloBuilders : MonoBehaviour {

	#region Public
	public GameObject Canvas;
	[Header("ATTENZIONE PARTE PROVVISORIA")]
	public CanvasGroup[] Group;
	#endregion

	#region Private
	private ManagerAnimations M_Animations;
	private ClusterSwitchButtons M_SwitchButtons;
	private ButtonStyle M_Style;
	#endregion

	void Awake()
	{

		M_Animations = Canvas.GetComponent<ManagerAnimations> ();
		M_SwitchButtons = Canvas.GetComponent<ClusterSwitchButtons> ();
		M_Style = Canvas.GetComponent<ButtonStyle> ();

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

}
