using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text[] timeText; 
    public AudioClip timeSound;
    public Text gameOverText;
    public AudioClip gameOverSound; 
    private AudioSource audioSource;
    public float time;
    private bool on_timer = false;
    private float on_time;
    private int min, sec;

    public void start_timer()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateTimeText();
        on_timer = true;
    }

    void Update()
    {
        if (on_timer)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = 0;
                PlayGameOverSound();
                gameOverText.gameObject.SetActive(true);
                timeText[0].text = "00";
                timeText[1].text = "00";

                foreach (Text t in timeText)
                {
                    t.gameObject.SetActive(false);
                }

            }
            else
            {
                min = (int)time / 60;
                sec = (int)time % 60;

                if (time <= 10 && !audioSource.isPlaying)
                {
                    PlayTimeSound();
                }

                UpdateTimeText();
            }
        }
    }

    private void UpdateTimeText()
    {
        timeText[0].text = min.ToString("00");
        timeText[1].text = sec.ToString("00");
    }

    private void PlayTimeSound()
    {
        audioSource.clip = timeSound; 
        audioSource.Play(); 
    }

    private void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
}
