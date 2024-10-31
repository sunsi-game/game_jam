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
        isBite = false; // �������� Ȯ��
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

    void OnBiteEvent() // �ٴ� ���� ���� �ø���
    {
        transform.SetParent(Dog.instance.mouthPosition); // ���� �� ��ġ �������� �ǹ��� �ű�
        transform.localPosition = Vector3.zero; // ��ü ��ġ �̵���Ŵ
        transform.localRotation = Quaternion.identity; // ��ü ȸ�� ����
    }

    void OffBiteEvent() // ���� �ٴڿ� ��������
    {
        // �ٴڿ� ��������
    }
}
