﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public CameraBehaviour cameraBehaviour;
    public CameraBehaviour[] cameraBehaviours;
    public float transitionSpeed;
    public GameObject canvas;
    public CanvasGroup menu;
	public CanvasGroup pannelloRisorse;

    private int activeCamera;
    private bool isMoving;

    private void Awake()
    {

        activeCamera = cameraBehaviour.cameraType;
        isMoving = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isMoving && (menu.alpha == 0 || menu.alpha == 1))
        {
            StartCoroutine(ChangeCamera());
        }
    }

    void LateUpdate()
    {
        cameraBehaviour.GetCameraBeahviour();   
    }

    public IEnumerator ChangeCamera()
    {

        switch(activeCamera)
        {
            case 0:

                GameManager.currentState = GameManager.GameState.BUILDING;

                cameraBehaviour.transform.position = transform.position;
                cameraBehaviour.transform.rotation = transform.rotation;

                activeCamera++;
                cameraBehaviour = cameraBehaviours[activeCamera];
                canvas.GetComponent<ButtonStyle>().FadeOut(pannelloRisorse);

                yield return StartCoroutine(MoveCameraSmooth(cameraBehaviour.transform.position, cameraBehaviour.transform.rotation));

                canvas.GetComponent<ButtonStyle>().FadeIn(menu);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                isMoving = false;

                break;

            case 1:
                
                activeCamera = 0;

				canvas.GetComponent<ButtonStyle>().FadeIn(pannelloRisorse);
                canvas.GetComponent<ButtonStyle>().FadeOut(menu);

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                yield return StartCoroutine(MoveCameraSmooth(cameraBehaviours[0].transform.position, cameraBehaviours[0].transform.rotation));

                cameraBehaviour = cameraBehaviours[activeCamera];

                GameManager.currentState = GameManager.GameState.EXPLORATION;

                isMoving = false;

                break;
        }

    }


    public IEnumerator MoveCameraSmooth(Vector3 toPosition, Quaternion toRotation)
    {

        isMoving = true;

        for (float t = 0f; t <= 1; t += Time.deltaTime / transitionSpeed)
        {
            transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, toRotation, t);
            transform.position = Vector3.Lerp(transform.position, toPosition, t);
            yield return null;
        }

    }
}
