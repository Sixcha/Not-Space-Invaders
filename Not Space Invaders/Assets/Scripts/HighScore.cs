using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI hiScoreText;

    public int oldHiScore;

    public string hiScoreString;

    // Start is called before the first frame update
    void Start()
    {
        hiScoreText = GetComponent<TextMeshProUGUI>();
        oldHiScore = PlayerPrefs.GetInt("highscore");
        hiScoreString = oldHiScore.ToString();
        hiScoreText.text = $"Highscore : {hiScoreString}";
    }

    // Update is called once per frame
    void Update()
    {
        if(oldHiScore < Score.score)
        {
            PlayerPrefs.SetInt("highscore",Score.score);
            hiScoreString = Score.score.ToString();
            hiScoreText.text = $"Highscore : {hiScoreString}";
        }
    }
}
