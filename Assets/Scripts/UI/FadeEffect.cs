using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeState { FadeIn = 0, FadeOUt, FadeOutIn, FadeLoop}

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime; // fadeSpeed 값이 10이면 1ch (값이 클수록 빠름)
    [SerializeField]
    private AnimationCurve fadeCurve;
    private Image image; // 페이드 효과 사용되는 바탕 이미지
    private FadeState fadeState; // 페이드 효과 상태

    private void Awake()
    {
        gameObject.SetActive(false);
        image = GetComponent<Image>();

        //StartCoroutine(Fade(0, 1)); // Fade Out
        //StartCoroutine(Fade(1, 0)); // Fade In

        //OnFade(FadeState.FadeOutIn);
    }

    public void OnFade(FadeState state)
    {
        fadeState = state;

        switch (fadeState)
        {
            case FadeState.FadeOutIn:
                StartCoroutine(FadeOutIn());
                break;
        }
    }
    private IEnumerator FadeOutIn()
    {

        while (true)
        {
            yield return StartCoroutine(Fade(0, 1));
            yield return StartCoroutine(Fade(1, 0));

            if(fadeState == FadeState.FadeOutIn)
            {
                break;
            }
        }
    }

    private IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            // 알파값을 start부터 end까지 fadeTime 시간 동안 변화시킨다.
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
            
        }
    }
}
