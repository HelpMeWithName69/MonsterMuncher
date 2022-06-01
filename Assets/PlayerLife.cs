using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public float Health = 100f;

    [SerializeField] private Text healthText;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            Health = Health - 25f;
            healthText.text = "Player Health: " + Health;
        }

        if (Health <= 0)
        {
            Health--;
            Application.LoadLevel("Lose");
        }

    }

}
