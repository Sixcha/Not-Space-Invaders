using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    //public GameObject player;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    float scoreTime = 0f;
    float lastUpdate = 0f;

    void Start()
    {
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        TimeScore();
        PresentScore(score);
    }

    public static void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    private void PresentScore(int score)
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = $"Score : {score}";
    }

    private void TimeScore()
    {
        if (Time.time - lastUpdate >= 1f)
        {
            UpdateScore(50);
            lastUpdate = Time.time;
        }
    }
}
