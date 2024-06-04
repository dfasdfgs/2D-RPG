using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image CharaterImg;
    public Text IdText;

    public Slider HpSlider;

    private GameObject player;
    public GameObject spawnPos;

    void Start()
    {
        IdText.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
    }

    void Update()
    {
        display();
    }

    private void display()
    {
        CharaterImg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerHP;
    }
}
