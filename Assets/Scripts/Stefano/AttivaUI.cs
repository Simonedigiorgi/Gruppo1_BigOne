﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttivaUI : MonoBehaviour
{

	private GameObject Canvas_;
	public GameObject ingenire;
	private ManagerAnimations b;
	private ButtonStyle c;
	public string PatternApertura;
	public string PatternChiusura;

	// Use this for initialization
	void Start () 
	{

		Canvas_ = GameObject.FindGameObjectWithTag ("Canvas");
		b = Canvas_.GetComponent<ManagerAnimations> ();
		c = Canvas_.GetComponent<ButtonStyle> ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.F))
		{

			//b.GoAnimation ("Pannelli_MainMenu");
			b.GoPattern (PatternApertura);
			c.ChangeCameraSequanzial ();
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			ingenire.GetComponent<CharacterController> ().enabled = false;

		}

		if (Input.GetKeyDown (KeyCode.G)) 
		{

			//b.GoAnimation ("Pannelli_MainMenu_back");
			b.GoPattern(PatternChiusura);
			c.ReturnToMainCamera ();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			ingenire.GetComponent<CharacterController> ().enabled = true;

		}
		
	}
}
