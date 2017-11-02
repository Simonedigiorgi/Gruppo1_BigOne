using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour
{

    // State
    public enum State
    {
        DISABLED,
        ENABLED,
        READY,
        ACTIVED,
        RUNNING,
        STOPPED,
        COMPLETED
    }

    // Attributes
    public string activityName = "";                // The activity's name
    public float duration = 0f;                     // The activity's duration
    public float timer = 0f;                        // The timer
    public GameObject assignedPlayer = null;        // The player assigned to activity
    public Resource[] resourcesProduced;              // The resources needed for the activity
    public State currentState;
    public bool isCommon = false;                   // Check if the activity is common

    private bool isTriggered = false;               // Check if the activity is triggered

    private void Awake()
    {
        timer = duration;
        ActivityManager.availableActivities.Add(this);
    }

    private void Update()
    {
        if ((currentState == State.READY || currentState == State.ACTIVED) && Input.GetKeyDown(KeyCode.P))
        {
            ActivityManager.StartActivity(this.activityName);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (isCommon) assignedPlayer = other.gameObject;

        if (!assignedPlayer.GetComponent<PlayerControl>().active && isTriggered)
        {
            isTriggered = false;
        }

        switch (currentState)
        {

            case State.ENABLED:

                if (other.tag == "Player" && assignedPlayer == other.gameObject && assignedPlayer.GetComponent<PlayerControl>().active && !isTriggered)
                {

                    isTriggered = true;
                    currentState = State.READY;

                }

                break;

            case State.READY:

                if (other.tag == "Player" && assignedPlayer == other.gameObject && !assignedPlayer.GetComponent<PlayerControl>().active)
                {
                    isTriggered = true;
                    currentState = State.ENABLED;
                }

                break;

            case State.STOPPED:

                if (other.tag == "Player" && assignedPlayer == other.gameObject && assignedPlayer.GetComponent<PlayerControl>().active && !isTriggered)
                {
                    isTriggered = true;
                    currentState = State.ACTIVED;
                }

                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {

        switch (currentState)
        {
            case State.READY:

                if (other.tag == "Player" && assignedPlayer == other.gameObject)
                {
                    isTriggered = false;
                    currentState = State.ENABLED;

                }

                break;
            case State.RUNNING:
            case State.ACTIVED:

                if (other.tag == "Player" && assignedPlayer == other.gameObject)
                {
                    isTriggered = false;
                    currentState = State.STOPPED;
                    ActivityManager.StopActivity(this.activityName);

                }

                break;
        }

    }

    public void SetCompletedActivity()
    {
        currentState = State.COMPLETED;

        GameObject module = this.gameObject.transform.GetChild(0).gameObject;
        Renderer[] renderers = module.GetComponentsInChildren<Renderer>();

        module.GetComponent<Module>().activedState = Module.ModuleState.BUILDED;

        foreach (var r in renderers)
        {

            r.enabled = true;
            r.sharedMaterial.color = Color.green;
            Debug.Log("Color il componente");
        }

        ///this.gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
    }


}
