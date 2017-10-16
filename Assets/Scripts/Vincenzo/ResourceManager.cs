using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceManager {

    public static Dictionary<string, int> resourcesAvailable = new Dictionary<string, int>(); // Dictionary of available resources

    /// <summary>
    /// Increaseses the resources when the player collects it.
    /// </summary>
    /// <param name="resource">The object Resource.</param>
    public static void IncreasesResources(Resource resource)
    {

        // Checks if the resource is already in the dictionary
        if(!resourcesAvailable.ContainsKey(resource.resourceName))
        {
            // If the resource isn't already in the dictionary, adds it
            resourcesAvailable[resource.resourceName] = resource.quantity;
        }
        else
        {
            // If the resource is already in the dictionary, upgrades the quantity
            resourcesAvailable[resource.resourceName] += resource.quantity;
        }

    }

    /// <summary>
    /// Increaseses the resources at the end of an activity.
    /// </summary>
    /// <param name="resourceName">Resource name.</param>
    /// <param name="resourceQuantity">Resource quantity.</param>
    public static void IncreasesResources(string resourceName, int resourceQuantity)
    {
        // Checks if the resource is already in the dictionary
        if (!resourcesAvailable.ContainsKey(resourceName))
        {
            // If the resource isn't already in the dictionary, adds it
            resourcesAvailable[resourceName] = resourceQuantity;
        }
        else
        {
            // If the resource is already in the dictionary, upgrades the quantity
            resourcesAvailable[resourceName] += resourceQuantity;
        }

    }

    /// <summary>
    /// Decreaseses the resources.
    /// </summary>
    /// <param name="resourceName">Resource name.</param>
    /// <param name="resourceQuantity">Resource quantity.</param>
    public static void DecreasesResources(string resourceName, int resourceQuantity)
    {

        // Downgrades the quantity
        resourcesAvailable[resourceName] -= resourceQuantity;

    }

    public static bool ChecksResourcesAvailibility(string resourceName, int resourceQuantity)
    {
        // Checks if the resource is already in the dictionary
        if (!resourcesAvailable.ContainsKey(resourceName))
        {
            // If the resource isn't in the dictionary, return false
            return false;
        }
        else
        {
            int quantity = resourcesAvailable[resourceName];

            // If the resource is in the dictionary and there is enough quantity of it, return true
            if (quantity >= resourceQuantity) return true;

            // If the resource is in the dictionary and there isn't enough quantity of it, return false
            return false;
        }
    }


    public static void Print()
    {
        foreach(KeyValuePair<string, int> resource in resourcesAvailable)
        {
            Debug.Log(resource.Key + ": " + resource.Value);
        }
    }

}
