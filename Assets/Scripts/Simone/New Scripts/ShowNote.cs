using UnityEngine;

public class ShowNote : MonoBehaviour {

    [TextArea]
    [Tooltip("Important notes about the CameraBase Position")]
    public string NOTES = "Remember to set the CameraBase transform position at the same place of the Player 1 position. If not the camera will NOT WORK, MOVE THE MOUSE to connect the camera to the player (it's a bit buggy)";
                          

}
