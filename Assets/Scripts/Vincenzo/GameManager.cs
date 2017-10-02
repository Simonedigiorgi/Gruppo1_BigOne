using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] players;
    public int activePlayer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ChangePlayer();
        }
		
	}

    void ChangePlayer()
    {
        PlayerControl playerManager = players[activePlayer].GetComponent<PlayerControl>();
        playerManager.active = false;
        activePlayer++;

        if(activePlayer >= players.Length)
        {
            activePlayer = 0;
        }

        players[activePlayer].GetComponent<PlayerControl>().active = true;


        CameraController cameraManager = Camera.main.GetComponent<CameraController>();
        cameraManager.player_1 = players[activePlayer].transform;
        cameraManager.pivot.transform.position = cameraManager.player_1.transform.position;
        cameraManager.pivot.transform.parent = cameraManager.player_1.transform;

    }
}
