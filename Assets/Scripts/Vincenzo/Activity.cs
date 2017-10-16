using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour {

    public string activityName = "";
    public float duration = 0f;
    public float timer = 0f;
    public bool isActive = false;
    public bool isEnabled = false;
    public bool isCommon = false;
    public GameObject assignedPlayer = null;

    private bool triggered = false;

    private void Awake()
    {
        timer = duration;
        ActivityManager.availableActivities.Add(this);
    }

    private void Update()
    {
        if(this.triggered && Input.GetKeyDown(KeyCode.P) && !this.isActive && assignedPlayer.GetComponent<PlayerControl>().active)
        {
            ActivityManager.StartActivity(this.activityName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isCommon && isEnabled) assignedPlayer = other.gameObject;
            
        if(other.tag == "Player" && assignedPlayer == other.gameObject && isEnabled && !triggered)
        {
            this.triggered = true;
            print(other.name + "Enter");
        }
    }

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && assignedPlayer == other.gameObject && isEnabled && triggered)
		{
            this.triggered = false;
            print(other.name + "Exit");
            if(this.isActive)
            {
                ActivityManager.StopActivity(this.activityName);
            }
		}
	}

    public void SetCompletedActivity()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }


}
