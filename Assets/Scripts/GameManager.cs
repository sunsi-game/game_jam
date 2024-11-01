using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


// restart ����� ������
// ����� �� �� image restart�� ������ �ʰ� ����
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

    //restart ��ư�� ������
    public void OnClickRestart()
    {
        //ù ����� �������� �ȴ�.
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
        Debug.Log("���� ����");

        #if UNITY_EDITOR    
        EditorApplication.isPlaying = false; // �����Ϳ��� ������ ����
        #else
        Application.Quit(); // ����� ���ø����̼ǿ��� ����
        #endif
    }
}