using UnityEngine;

public class GameOptions : MonoBehaviour
{
    public static int difficulty;

    void Start()
    {
        if(PlayerPrefs.GetInt("difficulty") == 0)
        {
            PlayerPrefs.SetInt("difficulty",2);
        }
        difficulty = PlayerPrefs.GetInt("difficulty");
    }
    public void SetDifficulty(int newDifficulty)
    {
        PlayerPrefs.SetInt("difficulty",newDifficulty);
        difficulty = newDifficulty;
    }
}

