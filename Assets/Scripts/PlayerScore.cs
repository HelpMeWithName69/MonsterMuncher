using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public float Score = 0f;

    [SerializeField] private Text scoreText;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            Score = Score + 1f;
            scoreText.text = "Score: " + Score;
        }

        if (Score >= 2)
        {
            Score--;
            Application.LoadLevel("Win");
        }

    }
}
