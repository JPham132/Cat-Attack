using UnityEngine;

public class SnakeCreation : MonoBehaviour
{
    //Snake and spawn rate of the snake
    public GameObject snake;
    public float spawn_rate = 6;

    //Timer
    float timer = 0;

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
    }
}
