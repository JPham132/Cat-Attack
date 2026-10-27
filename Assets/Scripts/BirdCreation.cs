using UnityEngine;

public class BirdCreation : MonoBehaviour
{
    //Create the bird and spawn rate of the birds
    public GameObject bird;
    public float spawn_rate = 3;

    //Timer for the birds
    float timer = 0;

    void Start()
    {
        
    }

   
    void BirdSpawn()
    {
        //Creates a new bird object at height between 2 and 3
        float height = Random.Range(2f, 4f);

        Instantiate(bird, new Vector2(-10, height), Quaternion.identity);
    }

    void Update()
    {
        //Update the timer
        timer = timer + Time.deltaTime;

        //Every time the timer gets past the spawn rate, then it will create a bird
        if(timer >= spawn_rate)
        {
            BirdSpawn();

            timer = 0;
        }
    }
}
