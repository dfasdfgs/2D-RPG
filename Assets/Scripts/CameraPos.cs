using UnityEngine;

public class CameraPos : MonoBehaviour
{
    private GameObject playerObj;

    void Start()
    {

    }

    void Update()
    {
        if(playerObj == null)
        {
            playerObj = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            transform.position = new Vector3(playerObj.transform.position.x, playerObj.transform.position.y + 2, transform.position.z);
        }
    }
}
