using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject exitGround;
    public GameObject fadeEffectObject;
    public void Interact()
    {
        OnDigEnvent();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnDigEnvent()
    {
        FadeEffect fadeEffect = fadeEffectObject.GetComponent<FadeEffect>();
        fadeEffect.gameObject.SetActive(true);
        fadeEffect.OnFade(FadeState.FadeOutIn);

        float yInterval = Dog.instance.transform.position.y - transform.position.y; // 기존 y축 저장
        Dog.instance.transform.position = new Vector3(exitGround.transform.position.x,yInterval,0); // 위치 변환
    }


}
