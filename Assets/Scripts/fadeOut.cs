using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour
{
    public Image FadeImage;//���̵� �ƿ� ȿ���� ���� ������
    public Text FadeText; //���̵�ƿ��� �Բ� ����� �ؽ�Ʈ
    private float fadeAlpha = 1.0f; //���̵� �ƿ� ȿ���� �ӵ��� �����ϴ� ����

    private AudioSource backSource;//���̵� �ƿ��� ������ ����� �������

    void Start()
    {
        backSource = GetComponent<AudioSource>();
        FadeImage.gameObject.SetActive(true); //�������ڸ��� ���̵� �ƿ� ȿ���� �ִ� �г��� Ȱ��ȭ�Ѵ�.
        StartCoroutine(Fade()); //�ڷ�ƾ�� ���۵�
    }

    void Update()
    {
    
    }
    private IEnumerator Fade()
    {
        while (fadeAlpha >= 0) //fadeAlpha�� 0�� �� �� '����' �ݺ�.
        {
            fadeAlpha -= 0.03f; //�� �� �ݺ��� ��  fadeAlpha�� 0.03�� �پ���.

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, fadeAlpha);
            FadeText.color = new Color(FadeText.color.r, FadeText.color.g, FadeText.color.b, fadeAlpha);
            //ȭ�� ���� �г��� ���� ���� �ƴ϶� ������ �����ϴ� ���̱⿡ color.

            yield return new WaitForSeconds(0.02f);
            //0.02�ʸ� ����ϰ� �ٽ� while���� ó������ ���ư���.
        }
        backSource.Play();
        //while���� ����Ǹ� ��������� ����ȴ�...
    }

}
