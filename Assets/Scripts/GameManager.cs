using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isClear;

    public void SetClear() // ½Â¸® ¼³Á¤
    {
        isClear = true;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        isClear = false;
    }


    void Update()
    {
        
    }
}
