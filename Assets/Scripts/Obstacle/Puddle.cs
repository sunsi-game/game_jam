using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("GrandMother"))
            {
                collision.gameObject.GetComponent<GrandMother>().Death();
            }
            if (collision.gameObject.CompareTag("KeyItem"))
            {
                GameManager.instance.SetClear(); // KeyItem�� �����ϸ� clear���� 1 �ø�
            }
        }


    }
}
