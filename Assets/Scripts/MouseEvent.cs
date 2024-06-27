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
        MouseCilck(); //��� �ݿ��� ���� Input �Է� ���� + Update �޼��带 ���ƴ�.
    }

    private void MouseCilck()
    {
        if(Input.GetMouseButtonDown(0)) //������ ���ϴ��� ����(0,0)���� ���콺 ��ǥ ���� ��ȯ�ϴ� �Լ�.
        {
            Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Pos, Vector2.zero, 0f);

            if(hit.collider != null) //���� Ŭ���� �ڸ��� �ƹ��͵� ���� �ʴٸ� = ���� �ִٸ� �Լ� ����.
            {
                if(hit.collider.gameObject.name == "PowerNPC") //Ŭ���� ���� ���� ������Ʈ PowerNPC�� �ִٸ� �Լ� ����.
                {
                    Debug.Log(" Power NPC ����");
                    Power_UI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "BattleNPC")//Ŭ���� ���� ���� ������Ʈ BattleNPC�� �ִٸ� �Լ� ����.
                {
                    Debug.Log(" Battle NPC����");
                    battle_UI.SetActive(true);
                }
                else if (hit.collider.gameObject.name == "PotionNPC")//Ŭ���� ���� ���� ������Ʈ PotionNPC�� �ִٸ� �Լ� ����.
                {
                    Debug.Log(" Potion NPC ����");
                    Potion_UI.SetActive(true);
                }
            }
        }
    }
}
