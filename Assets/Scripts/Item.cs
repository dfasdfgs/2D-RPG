using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 10;
                Debug.Log("Player Coin : " + GameManager.Instance.Coin);
                Destroy(gameObject);
            }
            else if(gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHP += 10;
                Debug.Log("Player HP : " + GameManager.Instance.PlayerHP);
                Destroy(gameObject);

            }
            else if (gameObject.tag == "Speed")
            {
                GameManager.Instance.player.GetComponent<Character>().Speed += 10;
                Debug.Log("Player Speed : " + GameManager.Instance.player.GetComponent<Character>().Speed);
                Destroy(gameObject);

            }
            else if (gameObject.tag == "DamageUp")
            {
                GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage += 5;
                Debug.Log("Player Damage : " + GameManager.Instance.player.GetComponent<Character>().AttackObj.GetComponent<Attack>().AttackDamage);
                Destroy(gameObject);

            }
        }
    }

}
