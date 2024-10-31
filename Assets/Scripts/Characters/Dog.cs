using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dog : MonoBehaviour
{
    public static Dog instance; // 싱글톤 인스턴스

    public UnityEvent onInteraction; // 물기 이벤트 정의
    public Transform mouthPosition; // 개의 입 위치
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
            onInteraction.Invoke();
            DetectInteraction();
        }
    }
    void DetectInteraction()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, biteRange);

        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); // 감지된 BiteObject에 알림
            }
        }
    }

}
