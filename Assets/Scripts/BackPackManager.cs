using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;
    public GameObject BackPack_UI;
    public Text CoinText;

    public Image[] Itemimages;
    private InventoryItemDate[] InventoryItemDates;

    private void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        InventoryItemDates = new InventoryItemDate[Itemimages.Length];
    }

    void Update()
    {
        BackPackUIOn();
        CoinText.text = $"Coin: {GameManager.Instance.Coin:N0}";
    }

    private void BackPackUIOn()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            BackPack_UI.SetActive(!BackPack_UI.activeSelf);
        }
    }

    public bool AddItem(InventoryItemDate item)
    {
        for (int i = 0; i < Itemimages.Length; i++)
        {
            if (Itemimages[i].sprite == null)
            {
                Itemimages[i].sprite = item.itemImage;
                InventoryItemDates[i] = item;
                return true;
            }
        }
        return false;
    }
}
