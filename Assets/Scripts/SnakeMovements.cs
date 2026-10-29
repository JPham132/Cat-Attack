using UnityEngine;

public class SnakeMovements : MonoBehaviour
{
    //Speed of the flying snake
    public float snake_speed = 4;

    //Boundary for the snake (similar to the cat)
    public float right_boundary = 10;

    //Helper method for when the cat touches the flying snake
    void CatTouchesSnake(Collider2D cat)
    {
        if(cat.gameObject.name == "Cat")
        {
            //Get the cat controls and play the snake collision noise
            CatControls cat_con = cat.GetComponent<CatControls>();
            cat_con.SnakeSound();

            //Decreases the health and destroys the snake
            Health.decreaseHealth();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D touch)
    {
        CatTouchesSnake(touch);
    }

    void Update()
    {
        //Reused code from BirdMovements for the snake
        transform.position = new Vector2(transform.position.x + snake_speed * Time.deltaTime, transform.position.y);

        if(transform.position.x > right_boundary)
        {
            Destroy(gameObject);
        }
    }
}
