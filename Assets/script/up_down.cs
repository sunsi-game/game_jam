using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    public Transform holdPoint; 
    public float pickupRange = 0.2f;
    private GameObject heldObject; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (heldObject == null)
            {
                PickUpObject(); 
            }
            else
            {
                DropObject();
            }
        }

        
        if (heldObject != null)
        {
            heldObject.transform.position = holdPoint.position;
        }
    }

    void FixedUpdate()
    {
        // Rigidbody update
    }

    void PickUpObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, pickupRange);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Box")) 
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                
                if (distance <= pickupRange)
                {
                    heldObject = collider.gameObject;

                    
                    Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.isKinematic = true; 
                        rb.velocity = Vector2.zero; 
                        rb.angularVelocity = 0f;
                    }

                    heldObject.transform.position = holdPoint.position;
                }
                break;
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            Rigidbody2D rb = heldObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false;
                rb.velocity = Vector2.zero; 
                rb.angularVelocity = 0f; 
            }

            heldObject = null;
        }
    }
}
