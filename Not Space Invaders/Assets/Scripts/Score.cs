using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    //public GameObject player;
    public TextMeshProUGUI scoreText;
    public float score = 0f;
    public static int realScore;
    public static string scoreString;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score : 0";
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime; 
        realScore = (int)Math.Floor(score) * 50;
        scoreString = realScore.ToString();
        scoreText.text = $"Score : {scoreString}";
    }
}
