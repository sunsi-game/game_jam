using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FadeState { FadeIn = 0, FadeOUt, FadeOutIn, FadeLoop}

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime; // fadeSpeed ���� 10�̸� 1ch (���� Ŭ���� ����)
    [SerializeField]
    private AnimationCurve fadeCurve;
    private Image image; // ���̵� ȿ�� ���Ǵ� ���� �̹���
    private FadeState fadeState; // ���̵� ȿ�� ����

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

            // ���İ��� start���� end���� fadeTime �ð� ���� ��ȭ��Ų��.
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
            
        }
    }
}
