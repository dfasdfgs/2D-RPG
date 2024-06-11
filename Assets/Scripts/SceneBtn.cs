using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBtn : MonoBehaviour
{
    public void HomeBtn()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void ChangeBtn()
    {
        SceneManager.LoadScene("SelectScene");
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
}
