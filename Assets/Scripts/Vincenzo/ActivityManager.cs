using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActivityManager {

    public static List<Activity> availableActivities = new List<Activity>();
    public static List<Activity> completedActivities = new List<Activity>();

    public static void StartActivity(string name)
    {
        Activity activity = availableActivities.Find(x => x.activityName.Contains(name));
        activity.isActive = true;
        activity.StartCoroutine(StartTimerActivity(activity));
    }

	public static void StopActivity(string name)
	{
		Activity activity = availableActivities.Find(x => x.activityName.Contains(name));
        activity.isActive = false;
	}

    private static void CompleteActivity(Activity activity)
    {
        activity.isEnabled = false;
        completedActivities.Add(activity);
        availableActivities.Remove(activity);
        activity.SetCompletedActivity();
    }

	public static IEnumerator StartTimerActivity(Activity activity)
	{
        while (activity.timer > 1 && activity.isActive)
		{
			activity.timer -= Time.deltaTime * 1;
			yield return null;
		}
        if(activity.timer < 1) 
        {
			CompleteActivity(activity);
		}

	}

}
