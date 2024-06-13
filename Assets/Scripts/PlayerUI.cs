using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharaterImg;
    public Text IdText;

    public Slider HpSlider;

    private GameObject player;
    public GameObject spawnPos;

    public Text CoinCount;
    public Text MonsterCount;
    public Text speed; 
    public Text Damage;

    public GameObject GameClear;
    public float gameCount = 2f;

    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);

    }

    void Update()
    {
        display();
        CoinCount.text = "COIN : " + GameManager.Instance.Coin;
        MonsterCount.text = "Mob : " + GameManager.Instance.monsterCount;
        speed.text = "Speed : " + GameManager.Instance.player.GetComponent<Character>().Speed;
        Damage.text = "Damage : " + GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage;



        if (GameManager.Instance.monsterCount == 0)
        {
            GameClear.SetActive(true);

            gameCount -= Time.deltaTime;
            if (gameCount <= 0)
            {
                SceneManager.LoadScene("ExitScene");
            }
        }
    }

    private void display()
    {
        CharaterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHP;
    }
}
