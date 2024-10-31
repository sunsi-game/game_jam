using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteObject : MonoBehaviour, IInteractable
{
    private bool isBite;
    public void Interact()
    {
        if (isBite == false)
        {
            OnBiteEvent();
        }
        else if (isBite == true)
        { 
            OffBiteEvent();
        }
    }
    void Start()
    {
        isBite = false;
    }

    void Update()
    {
        
    }

    void OnBiteEvent()
    {
        transform.SetParent(Dog.instance.mouthPosition);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    void OffBiteEvent()
    {

    }
}
