using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


// restart 기능을 만들자
// 재시작 할 때 image restart를 보이지 않게 하자
public class GameManager : MonoBehaviour
{
    public GameManager instance;
    public bool isClear;
    public bool isGameOver;
    public GameObject imageRestart; private void Awake()
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


    // Start is called before the first frame update
    void Start()
    {
       
        isClear = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //restart 버튼을 누르면
    public void OnClickRestart()
    {
        //첫 장면을 가져오게 된다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetClear()
    {
        if (!isClear)
        {
            isClear = true;
            Debug.Log("clear");
        }
    }
    public void OnClickExit()
    {
        Debug.Log("게임 종료");

        #if UNITY_EDITOR    
        EditorApplication.isPlaying = false; // 에디터에서 실행을 종료
        #else
        Application.Quit(); // 빌드된 애플리케이션에서 종료
        #endif
    }
}