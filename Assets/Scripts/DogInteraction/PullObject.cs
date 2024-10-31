using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObject : MonoBehaviour, IInteractable
{
    Walk speed;
    float speedSave;
    bool isPull; // ���°�?
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isPull = false;
        speed = Dog.instance.GetComponent<Walk>();
        speedSave = speed.maxSpeed;
    }
    public void Interact()
    {
        OnPullEvent();
    }
    
    void OnPullEvent()
    {
        rb.isKinematic = true;
        isPull = true; // ����.
        transform.SetParent(Dog.instance.mouthPosition);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("di");
            // ���� �Կ� ������ ��ü�� �߷¸�ŭ �θ��� �߷¿� ����
            speed.maxSpeed = 0.0f;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isPull = false; // ���´�.
        speed.maxSpeed = speedSave;
        rb.isKinematic = false;
        transform.SetParent(null);
    }

}
