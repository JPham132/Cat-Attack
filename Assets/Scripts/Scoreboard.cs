using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    //Score variables for updating the points
    public static int score;
    public TMP_Text current_score;

    //High score variables for keeping the highest score
    public static int high_score;
    public TMP_Text high_score_text;

    //Double point activation and timer for double points
    public static bool double_p = false;
    public static float double_p_timer = 0;

    //Increase the score when the cat catches something
    public static void IncreaseScore(int points)
    {
        //Double the points if it is true
        if(double_p == true)
        {
            points = points * 2;
        }

        //Add to the score
        score = score + points;
        

        //Sets the high score
        if(score > high_score)
        {
            high_score = score;

            PlayerPrefs.SetInt("HighScore", high_score);
        }
    }

    public static void DoublePoints()
    {
        double_p = true;
        double_p_timer = 10;
    }

    void Start()
    {
        //Reset the score when the game is restarted
        score = 0;

        //Gets the high score
        high_score = PlayerPrefs.GetInt("HighScore", 0);

        //Reset the double points
        double_p = false;
        double_p_timer = 0;
    }

    void Update()
    {
        //Update the current score and highh score
        current_score.text = "Score: " + score;
        high_score_text.text = "High Score: " + high_score;

        //Check for if double points is on
        if(double_p == true)
        {
            //Decrease the time
            double_p_timer = double_p_timer - Time.deltaTime;

            //If it reaches 0, turn off double points
            if(double_p_timer < 1)
            {
                double_p = false;
                double_p_timer = 0;
            }
        }
    }

}
