using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectScene : MonoBehaviour
{
    public Text IdText;

    void Update()
    {
        IdText.text = "ID : " + GameManager.Instance.UserID;
    }
}
