using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dog : MonoBehaviour
{
    public static Dog instance; // �̱��� �ν��Ͻ�

    public UnityEvent onInteraction; // ���� �̺�Ʈ ����
    public Transform mouthPosition; // ���� �� ��ġ
    public float biteRange = 2.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            DetectInteraction();
        }
    }
    void DetectInteraction()
    {
        int layerMask = LayerMask.GetMask("Interactable"); // Interactable ���̾� ������Ʈ�� ����(�÷��̾� ����)
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, biteRange, layerMask);

        if (hit.collider != null)
        {
            Debug.Log("Raycast �浹 ������: " + hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); // ������ BiteObject�� �˸�
            }
        }
    }

}
