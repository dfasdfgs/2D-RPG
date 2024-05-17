using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Infor")]
    public Text NameTxt;
    public Text FeatureTxt;
    public Image CharImage;

    [Header("Character")]
    public GameObject[] Character;
    private int charIndex = 0;

    public void SelectCharacterBtn(string btnName)
    {

        Character[charIndex].SetActive(false);

        if(btnName == "Next")
        {
            charIndex++;
            charIndex = charIndex % Character.Length;
        }

        if (btnName == "Prev")
        {
            charIndex--;
            charIndex = charIndex % Character.Length;
            charIndex = charIndex < 0 ? charIndex + Character.Length : charIndex;
        }

        Debug.Log($"charIndex: {charIndex}");
        Character[charIndex].SetActive(true);
    }
}
