using UnityEngine;

public class SnakeCreation : MonoBehaviour
{
    //Snake and spawn rate of the snake
    public GameObject snake;
    public float spawn_rate = 6;

    //Timer for spawning a snake and for when the game is the hardest
    float timer = 0;
    float faster_timer = 0;

    //The fastests that snakes are allowed to spawn in
    public float maximum_rate = 3.5f;

    void SnakeSpawn()
    {
        //Similar code to the cat
        float height = Random.Range(1f, 4f);

        //Creates the snake
        Instantiate(snake, new Vector2(-10,height), Quaternion.identity);
    }

    void Update()
    {
        //Increases the time 
        timer = timer + Time.deltaTime;

        //Creates a flying snake when the timer reaches 6
        if(timer >= spawn_rate)
        {
            SnakeSpawn();

            //Reset the time
            timer = 0;
        }

        //Increase the second timer for when snakes become harder
        faster_timer = faster_timer + Time.deltaTime;

        //Make the game harder every 15 seconds
        if(faster_timer >= 15)
        {
            //Spawn the snakes more often
            if(spawn_rate > maximum_rate)
            {
                spawn_rate = spawn_rate - 0.5f;
            }

            //Ensure it doesnt go past the maximum spawn rate of 3.5
            if(spawn_rate < maximum_rate)
            {
                spawn_rate = maximum_rate;
            }

            //Reset the faster timer
            faster_timer = 0;
        }
    }
}
