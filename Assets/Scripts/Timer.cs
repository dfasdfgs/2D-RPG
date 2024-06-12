using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float sec;
    int Min;
 
    [SerializeField] 
    public Text timetext;

    private void Update()
    {


        sec += Time.deltaTime;
        timetext.text = string.Format("{0:D2}Ка {1:D2}УЪ", Min, (int)sec);

        if ((int)sec > 59)
        {
            sec = 0; 
            Min++;

        }




    }
}
