using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ShootOnDrag : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject ballStartPos;
    // public AudioClip shootClip;
    ARGestureInteractor arGestureInteractor;
    ARSelectionInteractable arSelectionInteractable;
    Vector2 startDragPos;

    void OnEnable()
    {
        Debug.Log("PUTTER USED");
        arGestureInteractor = Camera.main.GetComponent<ARGestureInteractor>();
        arGestureInteractor.dragGestureRecognizer.onGestureStarted += OnDragRecognized;

        arSelectionInteractable = GetComponent<ARSelectionInteractable>();

        // if you wanted to execute code on select
        //arSelectionInteractable.selectEntered.AddListener(OnSelectTank);
    }

    // if you wanted to execute code on select
    //private void OnSelectTank(SelectEnterEventArgs args)
	//{
	//}

	void OnDisable()
    {
        arGestureInteractor.dragGestureRecognizer.onGestureStarted -= OnDragRecognized;
    }

    private void OnDragRecognized(DragGesture obj)
    {
        Debug.Log("DRAG START");

        // uncomment if you only want dragging to work after selecting (tapping) a tank to be active
        if (arSelectionInteractable.isSelected)
	    {
            if (!startDragPos.IsPointOverUIObject())
            {
                startDragPos = obj.position;

            // GetComponent<RotateScript>().isRotating = false;
            obj.onFinished += OnDragComplete;
            }
            
        }
    }

    private void OnDragComplete(DragGesture obj)
    {
        Debug.Log("DRAG COMPLETE");

        // uncomment if you only want dragging to work after selecting (tapping) a tank to be active
        //if (arSelectionInteractable.isSelected)
	    {
            GameObject newBall = Instantiate(ballPrefab);
            newBall.transform.position = ballStartPos.transform.position;

            // determine difference between start and end drag position
            // to use when calc force
            Vector2 diffVector = obj.position - startDragPos;

            // using a forward vector to shoot in direction tank is facing
            // adding a bit of y so there is an arc
            Vector3 ballForce = transform.forward + new Vector3(0f, 1f, 0f);

            // multiplying vector by the distance of drag (scaled by a number that works)
            ballForce *= (diffVector.magnitude * 0.01f);

            // using calculated vector in AddForce
            newBall.GetComponent<Rigidbody>().AddForce(ballForce, ForceMode.Impulse);

            // // play sound
            // GetComponent<AudioSource>().PlayOneShot(shootClip);
        }
    }

}
