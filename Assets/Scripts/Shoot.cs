using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class Shoot : MonoBehaviour
{
    GameObject projectilePrefab;
    ARGestureInteractor arGestureInteractor;

    void OnEnable()
    {
        arGestureInteractor = GetComponent<ARGestureInteractor>();
        arGestureInteractor.tapGestureRecognizer.onGestureStarted += TapDetect;
        arGestureInteractor.dragGestureRecognizer.onGestureStarted += DragDetect;

    }

    private void TapDetect (TapGesture obj)
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = transform.position;
        newProjectile.GetComponent<Rigidbody>().velocity = transform.forward * 5f;
    }

    private void DragDetect (DragGesture obj)
    {
        Debug.Log("You just dragged!");
        obj.onFinished += OnDragDone;
    }

    private void OnDragDone(DragGesture obj)
    {
        Debug.Log("Finished drag!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
