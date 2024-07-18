using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public GameObject SkillExplainUI;
    public Image skillImage;
    public Text skillText;

    public Image[] Skills;
    private float SkillSpeed = 6f;

    public void ExplainSkillBtn(int number)
    {
        SkillExplainUI.SetActive(true);
        skillImage.sprite = EventSystem.current.
            currentSelectedGameObject.GetComponent<Image>().sprite;

        switch (GameManager.Instance.SelectPlayer)
        {
            case Define.Player.Warrior:
                if (number == 0) skillText.text = "������ ù ��° ��ų";
                else if (number == 1) skillText.text = "������ �� ��° ��ų";
                else if (number == 2) skillText.text = "������ �� ��° ��ų";
                break;
            case Define.Player.Archer:
                if (number == 0) skillText.text = "�ü��� ù ��° ��ų";
                else if (number == 1) skillText.text = "�ü��� �� ��° ��ų";
                else if (number == 2) skillText.text = "�ü��� �� ��° ��ų";
                break;
            case Define.Player.Mage:
                if (number == 0) skillText.text = "�������� ù ��° ��ų";
                else if (number == 1) skillText.text = "�������� �� ��° ��ų";
                else if (number == 2) skillText.text = "�������� �� ��° ��ų";
                break;
        }
        Invoke("ExitExplain", 5f);
    }

    private void ExitExplain()
    {
        SkillExplainUI.SetActive(false);
    }

    private void Update()
    {
        SkillUse();
    }

    private void SkillUse()
    {
        if (GameManager.Instance.PlayerStat.Level >= 5)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (Skills[0].fillAmount >= 1) 
                {
                    GameManager.Instance.PlayerStat.MP -= 10f;
                    GameManager.Instance.Character.AttackAnimation();

                    GameObject playerPrefab = Resources.Load<GameObject>("Skill/W_SKILL_0");

                    Quaternion rotation = Quaternion.identity;
                    float speed = SkillSpeed;
                    if(GameManager.Instance.player.transform.localScale.x < 0)
                    {
                        rotation = Quaternion.Euler(0, 180, 0);
                        speed = SkillSpeed * -1;
                    }
                    GameObject obj = Instantiate(playerPrefab, GameManager.Instance.player.transform.position, rotation);
                    obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed,0), ForceMode2D.Impulse);
                    Destroy(obj, 5f);

                    StartCoroutine(SkillAmount(0));
                }
            }
        }

    }
    IEnumerator SkillAmount(int skillindex)
    {
        Skills[skillindex].fillAmount = 0f;
        while (Skills[skillindex].fillAmount < 1) 
        {
            Skills[skillindex].fillAmount += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
        Skills[skillindex].fillAmount = 1;
    }
}
