using UnityEngine;
using static Define;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //public string CharacterName;
    public Player SelectPlayer;
    public string UserID;

    public float PlayerHP = 100f;
    public float PlayerMP = 100f;
    public float PlayerExp = 100f;
    public float Player = 1f;
    public float PlayerDef = 1f;
    public int Coin = 0;

    public GameObject player;

    public Character Character
    {
        get { return player.GetComponent<Character>(); }
    }
    public Attack CharacterAttack
    {
        get { return Character.AttackObj.GetComponent<Attack>(); }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(Instance);
    }


    private void Start()
    {
        UserID = PlayerPrefs.GetString("ID");
    }

    public GameObject SpawnPlayer(Transform spawnPos)
    {
        GameObject Player = Resources.Load<GameObject>("Characters/" + SelectPlayer.ToString());
        player = Instantiate(Player, spawnPos.position, spawnPos.rotation);

        return player;
    }
}
