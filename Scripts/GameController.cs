using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int totalScore;
    public TextMeshProUGUI scoreText;

    public static GameController Instance;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }
    public void UpdateTotalScore()
    {
        this.scoreText.text = totalScore.ToString();

    }

   
}
