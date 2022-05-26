using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private Text scoreText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            score = score + 100;
            scoreText.text = "Score: " + score;
        }
    }
}
