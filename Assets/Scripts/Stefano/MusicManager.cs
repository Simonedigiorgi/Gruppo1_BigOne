using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script per la gestione del volume della musica e dei suoni
/// </summary>
public class MusicManager : MonoBehaviour {

	[Header("Slider per il volume della musica")]
	public Slider VolumeMusic;
	[Header("Slider per il volume dei suoni")]
	public Slider VolumeSounds;
	[Header("Componente che riproduce la musica")]
	public AudioSource Music;
	[Header("Componente che riproduce i suoni")]
	public AudioSource Sounds;
	
	// Update is called once per frame
	void Update () 
	{

		//Modifichiamo i volumi
		Music.volume = VolumeMusic.value;
		Sounds.volume = VolumeSounds.value;

	}

	/// <summary>
	/// Metodo che permette di salvare il valore dellla musica e dei suoni quando riapri l'applicazione
	/// </summary>
	public void SaveValue()
	{

		PlayerPrefs.SetFloat ("VolumeMuisc", Music.volume);
		PlayerPrefs.SetFloat ("VolumeSounds", Sounds.volume);

	}

}
