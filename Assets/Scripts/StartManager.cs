using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [Header("Menbership")]
    public GameObject MembershipUI;
    public InputField MembershipIDTxt;
    public InputField MembershipPWTxt;
    public InputField MembershipFindTxt;

    [Header("Login")]
    public GameObject LoginUI;
    public InputField LoginIDTxt;
    public InputField LoginPWTxt;

    [Header("Find")]
    public GameObject FindUI;
    public InputField FindFind;

    [Header("ErrorMessage")]
    public GameObject ErrorUI;
    public Text ErrorMessage;

    public void MembershipBtn()
    {

        PlayerPrefs.SetString("ID", MembershipIDTxt.text);
        PlayerPrefs.SetString("PW", MembershipPWTxt.text);
        PlayerPrefs.SetString("FIND", MembershipFindTxt.text);

        MembershipUI.SetActive(false);
        Debug.Log($"���� �Ϸ�!");

    }

    public void LoginBtn()
    {
        if (PlayerPrefs.GetString("ID") != LoginIDTxt.text)
        {
            LoginUI.SetActive(false);
            ErrorUI.SetActive(true);
            ErrorMessage.text = "���̵� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorMassageExit", 3f);
            return;
        }
        if (PlayerPrefs.GetString("PW") != LoginPWTxt.text)
        {
            LoginUI.SetActive(false);
            ErrorUI.SetActive(true);
            ErrorMessage.text = "��й�ȣ�� ��ġ���� �ʽ��ϴ�.";
            Invoke("ErrorMassageExit", 3f);
            return;
        }

        SceneManager.LoadScene("SelectScene");
    }

    private void OnMouseExit()
    {
        ErrorUI.SetActive(false);
    }

    public void FindBtn()
    {
        FindUI.SetActive(false);
        ErrorUI.SetActive(true);

        if (PlayerPrefs.GetString("FIND") == FindFind.text)
        {
            ErrorMessage.text = $"ID : {PlayerPrefs.GetString("ID")}\n PW: {PlayerPrefs.GetString("PW")}";
        }
        else
        {
            ErrorMessage.text = "�߸��� ��Ʈ�Դϴ�.";
        }
        Invoke("ErrorMassageExit", 3f);

    }

    public void Update()
    {
        Debug.Log("ID : " + PlayerPrefs.GetString("ID"));
        Debug.Log("PW : " + PlayerPrefs.GetString("PW"));
        Debug.Log("FIND : " + PlayerPrefs.GetString("FIND"));
    }
}
