using UnityEngine;

public class GoldenDuckCreation : MonoBehaviour
{
    //Golden duck object and lower spawn rate
    public GameObject golden_duck;
    public float spawn_rate = 15;

    //Timer
    float timer = 0;

    void DuckSpawn()
    {
        //Make the golden duck spawn higher up
        float height = Random.Range(3f, 4f);
        Instantiate(golden_duck, new Vector2(-10, height), Quaternion.identity);
    }

    void Update()
    {
        //Increase the time
        timer = timer + Time.deltaTime;

        //Create the golden duck when timer hits 15 seconds
        if(timer >= spawn_rate)
        {
            DuckSpawn();

            //Reset the time
            timer = 0;
        }
    }
}
