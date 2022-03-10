using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int scoreMultiplier;
  private void OnTriggerEnter2D(Collider2D collision)
    {
        Score.scoreText += scoreMultiplier;
    }
}
