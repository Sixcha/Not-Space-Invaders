using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    //public GameObject player;
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    float lastUpdate = 0f;

    void Start()
    {
        SetScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        TimeScore();
        PresentScore(score);
    }

    public static void SetScore(int scoreToSet)
    {
        score = scoreToSet;
    }

    public static void UpdateScore(int scoreToAdd)
    {
        if(PlayerController.isAlive == true)
        {
            score += scoreToAdd;
        }
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
