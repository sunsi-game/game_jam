using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isClear;
    private bool isGameOver;

    public delegate void GameStatusChange();
    public event GameStatusChange OnGameClear;
    public event GameStatusChange OnGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isClear = false;
        isGameOver = false;
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }*/

        if (isGameOver)
        {

        }
    }
    public void SetClear()
    {
        if (!isClear)
        {
            isClear = true;
            OnGameClear?.Invoke();
            Debug.Log("clear");
        }
    }

    public void SetGameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            OnGameOver?.Invoke();
            Debug.Log("over");
        }
    }
}
