using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStefano : MonoBehaviour 
{
	#region PRIVATE
	private Ray ray;
	#endregion

	#region PUBLIC
	[Header("Moduli istanziabili")]
	public GameObject[] Moduli;
	public GameObject Oggetto;

	[Header("Sezione debug applicazione")]
	public bool Line_RayCast;
	#endregion

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		MyDebug ();

		SelezioneModulo (1);

	}

	public void IstanziaModulo(Vector3 posizione)
	{

		//Codice per istanziare il modulo 

	}

	//Metodo che selezioni un modulo e lo istani 
	public void SelezioneModulo(int index)
	{

		//if ( Input.GetMouseButtonDown (0))
		//{ 
			RaycastHit hit; 
			ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

			if ( Physics.Raycast (ray,out hit,100.0f)) 
			{
				//StartCoroutine(ScaleMe(hit.transform));
				Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object



					Oggetto.transform.position = new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z);

			}

		//}

	}

	IEnumerable ScaleMe(Transform objTr) 
	{
		objTr.localScale *= 1.2f;
		yield return new WaitForSeconds(0.5f);
		objTr.localScale /= 1.2f;
	}

	private void MyDebug()
	{

		if (Line_RayCast == true) {

			Debug.DrawLine (ray.origin, ray.direction,Color.green);

		}

	}

}
