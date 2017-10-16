using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    public string resourceName = "";
    public int quantity = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ResourceManager.IncreasesResources(this);
            Destroy(this.gameObject);
        }
    }

}
