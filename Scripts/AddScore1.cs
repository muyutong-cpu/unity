using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore1 : MonoBehaviour
{
    public int score=100;
    public GemController target;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        GameController.Instance.totalScore += score;
        GameController.Instance.UpdateTotalScore();
        target.score += score;
       
    }
}
