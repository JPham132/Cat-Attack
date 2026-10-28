using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    //Score variables for updating the points
    public static int score;
    public TMP_Text current_score;

    //Increase the score when the cat catches something
    public static void IncreaseScore(int points)
    {
        score = score + points;
    }

    void Start()
    {
        //Reset the score when the game is restarted
        score = 0;
    }

    void Update()
    {
        //Update the current score
        current_score.text = "Score: " + score;
    }

}
