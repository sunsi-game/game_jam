using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("GrandMother"))
            {
                SceneManager.LoadScene("GameOver");
            }
            if (collision.gameObject.CompareTag("biteObj"))
            {
                SceneManager.LoadScene("Clear");
            }
        }


    }
}
