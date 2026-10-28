using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //The cat will start with 3 hearts
    public static int hearts = 3;

    //Create the three hearts
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    //Game Over Screen
    public GameObject game_over_panel;

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

    public static void IncreaseHealth()
    {
        //Adds an heart if there are less than 3 hearts
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
                //Restart the time
                Time.timeScale = 1;

                //Reloads the current scene
                string curr_scene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(curr_scene);
            }
        }
        
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

            //Show the game over screen and stop the game
            game_over_panel.SetActive(true);
            Time.timeScale = 0;
        }
        RestartGame();
        
    }
}
