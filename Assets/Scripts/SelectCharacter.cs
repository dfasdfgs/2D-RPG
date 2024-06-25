using System;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [Header("Infor")]
    public Text NameTxt;
    public Text FeatureTxt;
    public Image CharImage;

    [Header("Character")]
    public GameObject[] Character;
    public CharacterInfo[] characterInfos;
    private int charIndex = 0;

    [Header("GameStart")]
    public GameObject GameStart;
    public Text GameCountTxt;
    public bool IsPlayButtonClicked = false;
    private float gameCount = 5f;

    //public static string CharacterName;

    private void Start()
    {
        SetPanelInfo();
    }

    private void Update()
    {
        if (IsPlayButtonClicked)
        {
            gameCount -= Time.deltaTime;
            if (gameCount <= 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            GameCountTxt.text = $"곧 게임이 시작됩니다. \n {gameCount:F1}";
        }
    }

    public void PlayBtn()
    {
        GameStart.SetActive(true);
        IsPlayButtonClicked=true;
        Define.Player player = (Define.Player)Enum.Parse(typeof(Define.Player), Character[charIndex].name);
        GameManager.Instance.SelectPlayer = player;
        //GameManager.Instance.CharacterName = Character[charIndex].name;
        //CharacterName = Character[charIndex].name;
    }

    public void SelectCharacterBtn(string btnName)
    {
        Character[charIndex].SetActive(false);

        if (btnName == "Next")
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
        SetPanelInfo();
    }
    private void SetPanelInfo()
    {
        NameTxt.text = characterInfos[charIndex].Name;
        FeatureTxt.text = characterInfos[charIndex].Feature;
        CharImage.sprite = Character[charIndex].GetComponent<SpriteRenderer>().sprite;
    }
}
