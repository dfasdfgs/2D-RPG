using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject DialogueUI;

    private GameObject playerObj;
    private float distance;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  

    public GameObject[] DialogueTextObj;
    private int dlndex = 0;

    void Update()
    {
        if (playerObj == null) playerObj = GameManager.Instance.player;
        if (playerObj == null) return;

        distance = Vector2.Distance(transform.position, playerObj.transform.position);
        Debug.Log($"distance : {distance}");

        if (distance <= 3)
            DialogueUI.SetActive(true);
        else 
            DialogueUI.SetActive(false);
    }

    public void NextBtn(string name)
    {
        DialogueTextObj[dlndex].SetActive(false);
        if (name == "Next")
        {
            if (dlndex < DialogueTextObj.Length - 1) dlndex++;
        }
        else if (name == "Prev")
        {
            if (dlndex > 0) dlndex--;
        }
        DialogueTextObj[dlndex].SetActive(true);
    }

    public void TownBtn()
    {
        SceneManager.LoadScene("TownScene");
    }
}
