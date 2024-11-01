using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject exitGround;
    //public GameObject fadeEffectObject;
    public void Interact()
    {
        OnStairs();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnStairs()
    {
        //FadeEffect fadeEffect = fadeEffectObject.GetComponent<FadeEffect>();
        //fadeEffect.gameObject.SetActive(true);
        //fadeEffect.OnFade(FadeState.FadeOutIn);

                Dog.instance.transform.position = new Vector3(exitGround.transform.position.x, exitGround.transform.position.y, 0); // 위치 변환

    }
}
