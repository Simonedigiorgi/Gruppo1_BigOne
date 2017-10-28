using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAnimations : MonoBehaviour {

	#region Public
	public List<Pattern> ListaPattern;
	#endregion

	#region Private
	#endregion


	[System.Serializable]
	public class Pattern
	{

		[Header("Nome pattern")]
		public string NomePattern;
		[Header("Animazioni del pattern")]
		public List<Animazioni> ListaAnimazioni;
		[Header("Velocità pattern")]
		[Range(0.1f, 10.0f)]
		public float Accellerazione = 1;

	}

	[System.Serializable]
	public class Animazioni
	{
		[Header("Attivare l'oggetto prima dell'animazione?")]
		public bool AttivareOggetto = true;
		[Header("Disattivare l'oggetto dopo l'animazione?")]
		public bool DisattivaOggetto = false;
		public Animator Animator;
		public AnimationClip Clip;
		public string NomeClip;
		[Header("Solo se il campo 'Nome Clip' non è vuoto")]
		public float SpeedClip;

	}


	public void GoPattern(string NomePatter)
	{

		//cercare la lista di animazioni del pattern
		for (int i = 0; i < ListaPattern.Count; i++) 
		{
			
			if (ListaPattern [i].NomePattern == NomePatter) 
			{

				//Settare l'animator sulla giusta velocità
				for (int j = 0; j < ListaPattern [i].ListaAnimazioni.Count; j++) 
				{
					
					ListaPattern [i].ListaAnimazioni [j].Animator.speed = ListaPattern [i].Accellerazione;

				}

				StartCoroutine (GoAnimation (ListaPattern [i].ListaAnimazioni, ListaPattern [i].Accellerazione));

			}


		}


	}

	IEnumerator GoAnimation(List<Animazioni> Lista, float accellerazione)
	{

		//eseguire tutte le animazioni in successione
		for (int i = 0; i < Lista.Count; i++) 
		{

			if (Lista [i].AttivareOggetto == true) 
			{

				Lista [i].Animator.gameObject.SetActive (true);

			}

			if (Lista [i].Clip != null) 
			{
				Lista [i].Animator.Play (Lista [i].Clip.name);
				yield return new WaitForSeconds (Lista [i].Clip.length/accellerazione);
			} 
			else 
			{
				Lista [i].Animator.Play (Lista [i].NomeClip);
				yield return new WaitForSeconds (Lista [i].SpeedClip/accellerazione);
			}
			
			if (Lista [i].DisattivaOggetto == true) 
			{

				Lista [i].Animator.gameObject.SetActive (false);

			}

		}

		yield return null;

	}

}
