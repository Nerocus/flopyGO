using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int scoreText = 0;

    private void Start()
    {
        scoreText = 0;
    }
    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = scoreText.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            scoreText++;
        }
    }
}
