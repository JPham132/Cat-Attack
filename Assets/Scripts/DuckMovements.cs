using UnityEngine;

public class DuckMovements : MonoBehaviour
{
    //Speed and boundary of the Duck power up
    public float duck_speed = 6;
    public float right_boundary = 10;

    //Helper method to destroy the duck when the cat touches it and increase the health
    void CatTouchesDuck(Collider2D cat)
    {
        if(cat.gameObject.name == "Cat")
        {
            Health.IncreaseHealth();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D touch)
    {
        CatTouchesDuck(touch);
    }

    void Update()
    {
        //Make the duck move
        transform.position = new Vector2(transform.position.x + duck_speed * Time.deltaTime, transform.position.y);

        //Destroy the duck object after it leaves the screen
        if(transform.position.x >  right_boundary)
        {
            Destroy(gameObject);
        }
    }
}
