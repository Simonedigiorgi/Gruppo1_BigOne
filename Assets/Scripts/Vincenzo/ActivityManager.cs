using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ActivityManager
{

    public static List<Activity> availableActivities = new List<Activity>();
    public static List<Activity> completedActivities = new List<Activity>();

    public static void StartActivity(string name)
    {
        Activity activity = availableActivities.Find(x => x.activityName.Contains(name));

        //if (activity.currentState == Activity.State.READY) ResourceManager.DecreasesResources(activity.resourcesNeeded);

        activity.currentState = Activity.State.RUNNING;
        activity.percentage.transform.parent.gameObject.SetActive(true);

        activity.StartCoroutine(StartTimerActivity(activity));
    }

    public static void StopActivity(string name)
    {
        Activity activity = availableActivities.Find(x => x.activityName.Contains(name));
        activity.percentage.transform.parent.gameObject.SetActive(false);
    }

    private static void CompleteActivity(Activity activity)
    {
        completedActivities.Add(activity);
        availableActivities.Remove(activity);
        ResourceManager.IncreasesResources(activity.resourcesProduced);
        activity.SetCompletedActivity();
    }

    public static IEnumerator StartTimerActivity(Activity activity)
    {
        Image fillObject = activity.percentage.GetComponent<Image>();
        Text percentageText = activity.percentage.GetComponentInChildren<Text>();

        while (activity.timer < activity.duration && activity.currentState == Activity.State.RUNNING)
        {
            activity.timer += Time.deltaTime;
            fillObject.fillAmount = activity.timer / 10;
            percentageText.text = ((int)(fillObject.fillAmount * 10) * 10).ToString() + "%";
            yield return null;
        }
        if (activity.timer >= activity.duration)
        {
            CompleteActivity(activity);
        }

    }

}
