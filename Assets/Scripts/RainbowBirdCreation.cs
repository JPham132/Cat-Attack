using UnityEngine;

public class RainbowBirdCreation : MonoBehaviour
{
    //Rainbow bird and spawn rate for it
    public GameObject rainbow_bird;
    public float spawn_rate = 25;

    //Timer
    float timer = 0;

    //Create the rainbow bird
    void RainbowBirdSpawn()
    {
        float height = Random.Range(2f, 3.5f);
        Instantiate(rainbow_bird, new Vector2(-10, height), Quaternion.identity);
    }

    void Update()
    {
        //Increase the time
        timer = timer + Time.deltaTime;

        //Create the rainbow bird when the timer hits 25
        if(timer >= spawn_rate)
        {
            RainbowBirdSpawn();

            timer = 0;
        }
    }
}
