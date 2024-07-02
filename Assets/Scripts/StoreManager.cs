using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public InventoryItemDate[] items;
    public GameObject Purchase_UI;
    public Image ItemImage;
    public Text ItemNameText;
    public Text ItemCoinText;
    public Text ItemExplainText;

    private Dictionary<string, InventoryItemDate> itemDictionary;
    public string SelectedItemID;

    void Start()
    {
        itemDictionary = new Dictionary<string, InventoryItemDate>();
        foreach (InventoryItemDate item in items)
        {
            itemDictionary[item.itemID] = item;
        }
    }

  
    public void SelectItem(string itemID)
    {
        if (itemDictionary.TryGetValue(itemID, out InventoryItemDate selectdItem))
        {
            Purchase_UI.SetActive(true);
            ItemImage.sprite = selectdItem.itemImage;
            ItemNameText.text = selectdItem.itemName;
            ItemCoinText.text = $"({selectdItem.itemprice:N0} Point)";
            ItemExplainText.text = selectdItem.itemDescription;

            SelectedItemID = itemID;
        }
        else
        {
            Debug.LogError("Item ID not found: " + itemID);
        }
    }

    public void Purchase()
    {
        InventoryItemDate selectedItem = itemDictionary[SelectedItemID];
        if (GameManager.Instance.Coin >= selectedItem.itemprice)
        {
            if (BackPackManager.Instance.AddItem(selectedItem))
            {
                GameManager.Instance.Coin -= selectedItem.itemprice;
                Debug.Log("성공");
            }
            else
            {
                Debug.Log("인벤토리에 빈 공간이 없습니다.");
            }
        }
        else
        {
            Debug.Log($"잔액이 부족합니다. 잔액 : {GameManager.Instance.Coin}");
        }
    }
}
