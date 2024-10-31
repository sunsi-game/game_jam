using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Srat_Manager : MonoBehaviour
{
    public Image How_to_image;
    public GameObject X_button;
    public string load_scene_name;

    public void onClickStart()
    {
        Debug.Log("Game Start");
        SceneManager.LoadScene(load_scene_name);
    }

    public void onClickHowto()
    {
        How_to_image.enabled = true;
        X_button.SetActive(true);
    }

    public void onClickX()
    {
        How_to_image.enabled = false;
        X_button.SetActive(false);
    }
}
