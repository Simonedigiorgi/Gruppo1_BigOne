using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

	void Start () {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))                                            // Movement - LEFT MOUSE
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }

        if (Input.GetMouseButtonDown(1))                                            // Interaction - RIGHT MOUSE
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                // Do stuff
            }
        }
    }
}
