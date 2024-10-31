using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] timeText;
    public Text gameOverText;
    public float time;
    private int min, sec;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
        UpdateTimeText();
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 0;
            gameOverText.gameObject.SetActive(true);
            foreach (Text t in timeText)
            {
                t.gameObject.SetActive(false);
            }
            timeText[0].text = "00";
            timeText[1].text = "00";
        }
        else
        {
            min = (int)time / 60;
            sec = (int)time % 60;

            UpdateTimeText();
        }



    }

    private void UpdateTimeText()
    {
        timeText[0].text = min.ToString("00");
        timeText[1].text = sec.ToString("00");
    }
}