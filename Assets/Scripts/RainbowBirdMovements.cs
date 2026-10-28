using UnityEngine;

public class RainbowBirdMovements : MonoBehaviour
{
    //Speed and boundary for the rainbow bird
    public float rainbow_speed = 6;
    public float right_boundary = 10;
  
    //Helper method for when the cat touches the rainbow bird
    void CatTouchesRainbow(Collider2D cat)
    {
        if(cat.gameObject.name == "Cat")
        {
            //Activate double points for 10 seconds
            Scoreboard.DoublePoints();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D touch)
    {
        CatTouchesRainbow(touch);
    }
    

    void Update()
    {
        //Makes the rainbow bird move
        transform.position = new Vector2(transform.position.x + rainbow_speed * Time.deltaTime, transform.position.y);

        //Destroys the rainbow bird if it goes past the boundary
        if(transform.position.x > right_boundary)
        {
            Destroy(gameObject);
        }
    }
}
