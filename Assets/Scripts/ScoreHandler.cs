using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    int highScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        int highScore = 10;
        scoreText.text = "High score:" + highScore;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void PrintScore()
    {
        scoreText.text = "High score:" + highScore;
    }
}
