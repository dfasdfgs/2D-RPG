using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        MouseCilck();
    }

    private void MouseCilck()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.name == "PowerNPC")
                {
                    Debug.Log(" Power NPC 선택");
                }
                else if (hit.collider.gameObject.name == "BattleNPC")
                {
                    Debug.Log(" Battle NPC선택");
                }
                else if (hit.collider.gameObject.name == "PotionNPC")
                {
                    Debug.Log(" Potion NPC 선택");
                }
            }
        }
    }
}
