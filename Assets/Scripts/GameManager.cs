using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            DontDestroyOnLoad(gameObject); 
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
            Debug.Log("클리어");
        }
    }

    public void SetGameOver() 
    {
        if (!isGameOver) 
        {
            isGameOver = true;
            OnGameOver?.Invoke();
            Debug.Log("오버");
        }
    }
}

