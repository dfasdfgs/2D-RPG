using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Image[] ItemImages;
    public Text[] ItemTexts;
    public InventoryItemData[] ItemDatas;
    void Start()
    {
        for (int i = 0; i < ItemImages.Length; i++)
        {
            ItemImages[i].sprite = ItemDatas[i].itemImage;
            ItemTexts[i].text = $"{ItemDatas[i].itemName} ({ItemDatas[i].itemprice:N0}P)";
        }
    }
}
