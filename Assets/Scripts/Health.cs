using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    //The cat will start with 3 hearts
    public static int hearts = 3;

    //Create the three hearts
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    //Objects to help stop the game
    public CatControls cat_con;
    public BirdCreation bird_creation;
    public SnakeCreation snake_creation;
    public GoldenDuckCreation duck_creation;
    public RainbowBirdCreation rainbow_creation;

    //Game Over Screen and Audio
    public GameObject game_over_panel;
    public AudioSource game_over_noise;

    //Score text for game over screen
    public TMP_Text final_score;
    public TMP_Text curr_high_score;

    //Objects to hide the normal text when game over screen is displayed
    public GameObject score_text;
    public GameObject high_score_text;
    public GameObject double_points_text;
    
    //Boolean to check if the game over noise is played
    bool game_over_played = false;

    void Start()
    {
        //Hides the screen
        game_over_panel.SetActive(false);

        //Ensure that players have 3 hearts
        hearts = 3;
    }

    //Removes one heart from the cat
    public static void decreaseHealth()
    {
        hearts = hearts - 1;
    }

    //Adds one heart to the cat
    public static void IncreaseHealth()
    {
        //Adds a heart if there are less than 3 hearts
        if(hearts < 3)
        {
            hearts = hearts + 1;
        }
    }

    void RestartGame()
    {
        //If the player loses, allow the player to restart the game
        if(hearts < 1)
        {
            //Checks if P was pressed
            if(Keyboard.current.pKey.wasPressedThisFrame)
            {
                //Reloads the current scene
                string curr_scene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(curr_scene);
            }
        }
    }

    //Helper method to end the game
    void GameOver()
    {
        //Show the game over screen
        game_over_panel.SetActive(true);

        //Hide the in game UI
        score_text.SetActive(false);
        high_score_text.SetActive(false);
        double_points_text.SetActive(false);

        //Turn off the double points
        Scoreboard.double_p = false;
        Scoreboard.double_p_timer = 0;

        //Show the final score and high score
        final_score.text = "GAME SCORE: " + Scoreboard.score;
        curr_high_score.text = "HIGH SCORE: " + Scoreboard.high_score;

        //Stop the animals and cat
        cat_con.StopCat();
        cat_con.enabled = false;
        bird_creation.enabled = false;
        duck_creation.enabled = false;
        snake_creation.enabled = false;
        rainbow_creation.enabled = false;

        //Play the game over noise
        game_over_noise.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Shows all three hearts
        if(hearts == 3)
        {
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(true);
        }
        else if(hearts == 2)
        {
            //Shows only two of the hearts if the cat touches one of the snakes
            heart1.SetActive(true);
            heart2.SetActive(true);
            heart3.SetActive(false);
        }
        else if(hearts == 1)
        {
            //Shows only 1 heart if the cat has touched two of the snakes
            heart1.SetActive(true);
            heart2.SetActive(false);
            heart3.SetActive(false);
        }
        else
        {
            //No hearts remaining
            heart1.SetActive(false);
            heart2.SetActive(false);
            heart3.SetActive(false);

            //Show the game over screen, play the game over noise, and stop the game
            if(game_over_played == false)
            {
                GameOver();
                game_over_played = true;
            }
        }
        RestartGame();
    }
}
