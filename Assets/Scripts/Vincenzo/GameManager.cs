using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameState
    {
        EXPLORATION,
        BUILDING
    }

    public GameObject[] players;        // Players' array
    public Resource[] resources = ResourceManager.ResourcesAvailable;
    public static GameState currentState;

    private int activePlayer;            // The active player
    private CameraControl cameraControl;

    void Awake()
    {
        cameraControl = Camera.main.GetComponent<CameraControl>();
        currentState = GameState.EXPLORATION;

        /*foreach (Resource res in resources)
        {
            res.uiText.GetComponent<Text>().text = res.type.ToString() + ": " + res.quantity;
        }*/
    }

    // Update is called once per frame
    void Update()
    {

        // Change player with tab
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentState == GameState.EXPLORATION && players[activePlayer].GetComponent<CharacterController>().isGrounded)
            {
                int playerNumber = activePlayer;
                ChangePlayer(++playerNumber);
            }
                    

        }

        // Change player with numbers
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentState == GameState.EXPLORATION && players[activePlayer].GetComponent<CharacterController>().isGrounded)
            {
                ChangePlayer(0); // Number 1
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentState == GameState.EXPLORATION && players[activePlayer].GetComponent<CharacterController>().isGrounded)
            {
                ChangePlayer(1); // Number 2
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentState == GameState.EXPLORATION && players[activePlayer].GetComponent<CharacterController>().isGrounded)
            {
                ChangePlayer(2); // Number 3
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentState == GameState.EXPLORATION && players[activePlayer].GetComponent<CharacterController>().isGrounded)
            {
                ChangePlayer(3); // Number 4
            }
        }
    }

    /// <summary>
    /// Changes the active player.
    /// </summary>
    /// <param name="playerNumber">The player to activate.</param>
    void ChangePlayer(int playerNumber)
    {
        // Get the active player and deactivate it. 
        PlayerControl playerManager = players[activePlayer].GetComponent<PlayerControl>();
        playerManager.active = false;

        // Check if the player number is greater than array's length
        if (playerNumber >= players.Length)
        {
            playerNumber = 0;
        }

        // Activate the new player
        activePlayer = playerNumber;
        players[activePlayer].GetComponent<PlayerControl>().active = true;

        // Set the camera position to active player's position

        CameraControl cameraManager = Camera.main.transform.parent.GetComponent<CameraControl>();
        CameraBehaviour cameraBehaviour = cameraManager.cameraBehaviour;

        if (cameraBehaviour.cameraType == 0)
        {

            ThirdPersonCamera thirdPersonCamera = cameraBehaviour.gameObject.GetComponent<ThirdPersonCamera>();
            thirdPersonCamera.player_1 = players[activePlayer].transform;
            thirdPersonCamera.pivot.transform.position = thirdPersonCamera.player_1.transform.position;
            thirdPersonCamera.pivot.transform.parent = thirdPersonCamera.player_1.transform;

        }

    }
}
