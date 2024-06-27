using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject Potion_UI;
    public GameObject Power_UI;
    public GameObject battle_UI;
    void Update()
    {
        MouseCilck(); //즉시 반영을 위해 Input 입력 감지 + Update 메서드를 합쳤다.
    }

    private void MouseCilck()
    {
        if(Input.GetMouseButtonDown(0)) //게임의 좌하단을 기준(0,0)으로 마우스 좌표 값을 반환하는 함수.
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            if(hit.collider != null) //만약 클릭한 자리에 아무것도 없지 않다면 = 무언가 있다면 함수 실행.
            {
                if(hit.collider.gameObject.name == "PowerNPC") //클릭한 곳에 게임 오브젝트 PowerNPC가 있다면 함수 실행.
                {
                    Debug.Log(" Power NPC 선택");
                    Power_UI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "BattleNPC")//클릭한 곳에 게임 오브젝트 BattleNPC가 있다면 함수 실행.
                {
                    Debug.Log(" Battle NPC선택");
                    battle_UI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "PotionNPC")//클릭한 곳에 게임 오브젝트 PotionNPC가 있다면 함수 실행.
                {
                    Debug.Log(" Potion NPC 선택");
                    Potion_UI.SetActive(true);
                }
            }
        }
    }
}
