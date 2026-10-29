using UnityEngine;
using UnityEngine.InputSystem;

public class CatControls : MonoBehaviour
{
    //Speed of the cat moving left or right
    public float cat_speed = 6;

    //How far up the cat jumps
    public float jump_height = 22;

    //Check if the cat is on the ground
    bool touching_ground = true;

    //Rigid body of the cat
    Rigidbody2D cat_rb;

    //Animator for the cat
    Animator cat_ani;

    //Sprite for the cat
    SpriteRenderer cat_sprite;

    //The cat has passed away (may he rest in peace) sprite
    public Sprite dead_cat;

    //Audio for cat running/jumping
    public AudioSource cat_jumping;
    public AudioSource cat_running;

    //Audio for cat randomly meowing and timer
    public AudioSource meow;
    float meow_timer = 0;
    float meow_time;

    //Audio for cat catching an animal
    public AudioSource catch_sound;

    //Audio for when it touches a snake
    public AudioSource snake_sound;

    //Boundaries
    public float right = 8.5f;
    public float left = -8.5f;

    void Start()
    {
        //Retrieves the rigid body from the cat
        cat_rb = GetComponent<Rigidbody2D>();

        //Gets the sprite renderer from the cat
        cat_sprite = GetComponent<SpriteRenderer>();

        //Gets the animator
        cat_ani = GetComponent<Animator>();

        //Random time for the first meow
        meow_time = Random.Range(8f, 20f);
    }

    //Helper methods for playing noise
    public void CatchSound()
    {
        catch_sound.Play();
    }
    
    public void SnakeSound()
    {
        snake_sound.Play();
    }

    //Helper method to stop the cat when the game ends
    public void StopCat()
    {
        cat_rb.linearVelocity = new Vector2(0,0);

        //Stop the walking animation and noise
        cat_running.Stop();
        cat_ani.enabled = false;

        //Show the dead cat
        cat_sprite.sprite = dead_cat;
    }


    //Method to help check if the cat is touching the ground
    void CheckIfOnGround(Collision2D ground)
    {
        if(ground.gameObject.name == "Ground Bottom")
        {
            touching_ground = true;

            //Stop the jumping animation
            cat_ani.SetBool("jumping", false);
        }
    }

    //Unity method used to check for collision using helper method above
    void OnCollisionEnter2D(Collision2D touch)
    {
        CheckIfOnGround(touch);
    }

    void RandomMeow()
    {
        //Increase the time of the meow timer
        meow_timer = meow_timer + Time.deltaTime;

        //Random meow
        if(meow_timer >= meow_time)
        {
            meow.Play();
            meow_timer = 0;

            //New timer for the next meow
            meow_time = Random.Range(8f, 20f);
        }
    }

    void Update()
    {
        //Moves right when D is pressed on the keyboard and left when A is pressed
        if(Keyboard.current.dKey.isPressed)
        {
            cat_rb.linearVelocity = new Vector2(cat_speed, cat_rb.linearVelocity.y);

            //Walking animation
            cat_ani.SetBool("walking", true);

            //Face the cat to the right
            cat_sprite.flipX = false;

            //Play the running noise
            if((cat_running.isPlaying == false) && (touching_ground == true))
            {
                cat_running.Play();
            }
        }
        else if(Keyboard.current.aKey.isPressed)
        {
            cat_rb.linearVelocity = new Vector2(-cat_speed, cat_rb.linearVelocity.y);

            //Walking animation
            cat_ani.SetBool("walking", true);

            //Face the cat to the left
            cat_sprite.flipX = true;

            //Play the running noise
            if((cat_running.isPlaying == false) && (touching_ground == true))
            {
                cat_running.Play();
            }
        }
        else
        {
            //Does not move if A and D are not pressed
            cat_rb.linearVelocity = new Vector2(0, cat_rb.linearVelocity.y);

            //Cat is idling
            cat_ani.SetBool("walking", false);

            //Stop the running noise
            cat_running.Stop();
        }

        //Random Meow
        RandomMeow();

        //Jumps directly up when the space button is pressed
        if((Keyboard.current.spaceKey.wasPressedThisFrame) && (touching_ground == true))
        {
            cat_rb.linearVelocity = new Vector2(cat_rb.linearVelocity.x, jump_height);
            
            //Changes touching_ground to false because it is off the ground
            touching_ground = false;

            //Cat jumping Animation
            cat_ani.SetBool("jumping", true);

            //Stop the running noise when the cat jumps
            cat_running.Stop();

            //Jumping noise
            cat_jumping.Play();
        }

        //Boundaries for left and right
        if(transform.position.x < left)
        {
            //Ensures that the cat does not move past the left boundary
            transform.position = new Vector2(left, transform.position.y);
        }
        else if(transform.position.x > right)
        {
            //Ensures that the cat does not move past the right boundary
            transform.position = new Vector2(right, transform.position.y);
        }
    }
}
