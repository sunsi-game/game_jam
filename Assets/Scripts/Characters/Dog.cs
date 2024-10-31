using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dog : MonoBehaviour
{
    public static Dog instance;

    public UnityEvent onInteraction;
    public Transform mouthPosition;
    public float biteRange = 2.0f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DetectInteraction();
        }
        // Raycast ��θ� �ð�ȭ�մϴ�.
        Debug.DrawRay(mouthPosition.position, Vector2.down * biteRange, Color.red);

    }

    void DetectInteraction()
    {
        int layerMask = LayerMask.GetMask("Interactable");
        RaycastHit2D hit = Physics2D.Raycast(mouthPosition.position, Vector2.down, biteRange, layerMask);


        if (hit.collider != null)
        {
            Debug.Log("Raycast �浹 ������: " + hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.Log("Raycast �浹 ����");
            }
        }
    }
}