using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject target;
    
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void IncrementScore(){
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
}