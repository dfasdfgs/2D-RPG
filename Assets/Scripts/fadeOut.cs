using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour
{
    public Image FadeImage;//페이드 아웃 효과를 위한 가림막
    public Text FadeText; //페이드아웃과 함께 사라질 텍스트
    private float fadeAlpha = 1.0f; //페이드 아웃 효과의 속도를 결정하는 변수

    private AudioSource backSource;//페이드 아웃이 끝나면 재생될 배경음악

    void Start()
    {
        backSource = GetComponent<AudioSource>();
        FadeImage.gameObject.SetActive(true); //시작하자마자 페이드 아웃 효과를 주는 패널을 활성화한다.
        StartCoroutine(Fade()); //코루틴이 시작됨
    }

    void Update()
    {
    
    }
    private IEnumerator Fade()
    {
        while (fadeAlpha >= 0) //fadeAlpha가 0이 될 때 '까지' 반복.
        {
            fadeAlpha -= 0.03f; //한 번 반복될 때  fadeAlpha는 0.03씩 줄어든다.

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, fadeAlpha);
            FadeText.color = new Color(FadeText.color.r, FadeText.color.g, FadeText.color.b, fadeAlpha);
            //화면 가린 패널을 끄는 것이 아니라 투명도를 조정하는 것이기에 color.

            yield return new WaitForSeconds(0.02f);
            //0.02초를 대기하고 다시 while문의 처음으로 돌아간다.
        }
        backSource.Play();
        //while문이 종료되면 배경음악이 재생된다...
    }

}
