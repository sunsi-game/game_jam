using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteObject : MonoBehaviour, IInteractable
{
    private bool isBite;
    private Rigidbody2D rb;

    private void Start()
    {
        isBite = false;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Interact()
    {
        if (!isBite)
        {
            OnBiteEvent();
        }
    }

    private void OnBiteEvent()
    {
        Debug.Log("OnBiteEvent ȣ���");
        isBite = true;
        rb.isKinematic = true;
        transform.SetParent(Dog.instance.mouthPosition);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        gameObject.GetComponent<BoxCollider2D>().enabled = false; 
    }


    public void OffBiteEvent()
    {
        isBite = false;
        rb.isKinematic = false;
        transform.SetParent(null);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}