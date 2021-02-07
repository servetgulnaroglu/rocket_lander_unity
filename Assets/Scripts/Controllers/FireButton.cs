using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPowerOn;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        isPowerOn = true;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        isPowerOn = false;
    }
}
