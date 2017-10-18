using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskProgression : MonoBehaviour {

    public Transform LoadingBar;
    public Transform TextIndicator;
    //public Transform TextLoading;

    [SerializeField] private float currentAmont;
    [SerializeField] private float speed;

	void Start () {
		
	}
	
	void Update () {

        if(currentAmont < 100)
        {
            currentAmont += speed * Time.deltaTime;
            TextIndicator.GetComponent<Text>().text = ((int)currentAmont).ToString() + "%";
            //TextLoading.gameObject.SetActive(true);
        }
        else
        {
            //TextLoading.gameObject.SetActive(false);
            TextIndicator.GetComponent<Text>().text = "DONE";
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmont / 100;
		
	}
}
