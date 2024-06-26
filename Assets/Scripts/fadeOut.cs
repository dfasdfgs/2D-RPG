using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class fadeOut : MonoBehaviour
{
    public Image FadeImage;
    public Text FadeText;
    private float fadeAlpha = 1.0f;

    private AudioSource backSource;

    void Start()
    {
        backSource = GetComponent<AudioSource>();
        FadeImage.gameObject.SetActive(true);
        StartCoroutine(Fade());
    }

    void Update()
    {
    
    }
    private IEnumerator Fade()
    {
        while (fadeAlpha >= 0)
        {
            fadeAlpha -= 0.03f;

            FadeImage.color = new Color(FadeImage.color.r, FadeImage.color.g, FadeImage.color.b, fadeAlpha);
            FadeText.color = new Color(FadeText.color.r, FadeText.color.g, FadeText.color.b, fadeAlpha);

            yield return new WaitForSeconds(0.02f);
        }
        backSource.Play();
    }

}
