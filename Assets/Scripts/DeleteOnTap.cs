using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteOnTap : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData data)
    {
        Destroy(gameObject);
    }
}
