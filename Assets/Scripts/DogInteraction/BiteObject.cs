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
        isBite = false; // 물었는지 확인
        /*
        if(Dog.instance != null)
        {
            Dog.instance.onInteraction.AddListener(OnBiteEvent);
        }
        */
    }

    void Update()
    {
        
    }

    void OnBiteEvent() // 바닥 물건 물어 올리기
    {
        transform.SetParent(Dog.instance.mouthPosition); // 개의 입 위치 기준으로 피벗을 옮김
        transform.localPosition = Vector3.zero; // 물체 위치 이동시킴
        transform.localRotation = Quaternion.identity; // 물체 회전 변경
    }

    void OffBiteEvent() // 물건 바닥에 내려놓기
    {
        // 바닥에 내려놓기
    }
}
