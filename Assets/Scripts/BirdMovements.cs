using UnityEngine;

public class BirdMovements : MonoBehaviour
{
    //Speed of the bird
    public float bird_speed = 4;

    //Boundary for the bird
    public float right_boundary = 10;

    void Update()
    {
        //Make the bird move from left to right
        transform.position = new Vector2(transform.position.x + bird_speed * Time.deltaTime, transform.position.y);

        //If the bird goes off the screen, destroy the bird object
        if(transform.position.x > right_boundary)
        {
            Destroy(gameObject);
        }
    }

    //Helper method for what happens when the cat touches the bird
    void CatTouchesBird(Collider2D cat)
    {
        if(cat.gameObject.name == "Cat")
        {
            //Gets the cat controls and play the noise
            CatControls cat_con = cat.GetComponent<CatControls>();
            cat_con.CatchSound();
            
            //Destroy the bird object and add the points
            Scoreboard.IncreaseScore(7);
            Destroy(gameObject);
        }
        
    }

    void OnTriggerEnter2D(Collider2D decimate)
    {
        CatTouchesBird(decimate);
    }
}
