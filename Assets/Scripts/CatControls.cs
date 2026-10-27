using UnityEngine;
using UnityEngine.InputSystem;

public class CatControls : MonoBehaviour
{
    //Speed of the cat moving left or right
    public float cat_speed = 6;

    //How far up the cat jumps
    public float jump_height = 7;

    //Check if the cat is on the ground
    bool touching_ground = true;

    //Rigid body of the cat
    Rigidbody2D cat_rb;

    //Boundaries
    public float right = 8.5f;
    public float left = -8.5f;

    void Start()
    {
        //Retrieves the rigid body from the cat
        cat_rb = GetComponent<Rigidbody2D>();

        Debug.Log("CatControls is running");
    }

    //Method to help check if the cat is touching the ground
    void CheckIfOnGround(Collision2D ground)
    {
        if(ground.gameObject.name == "Ground Bottom")
        {
            touching_ground = true;
        }
    }

    //Unity method used to check for collision using helper method above
    void OnCollisionEnter2D(Collision2D touch)
    {
        CheckIfOnGround(touch);
    }

    void Update()
    {
        //Moves right when D is pressed on the keyboard and left when A is pressed
        if(Keyboard.current.dKey.isPressed)
        {
            cat_rb.linearVelocity = new Vector2(cat_speed, cat_rb.linearVelocity.y);
        }
        else if(Keyboard.current.aKey.isPressed)
        {
            cat_rb.linearVelocity = new Vector2(-cat_speed, cat_rb.linearVelocity.y);
        }
        else
        {
            //Does not move if A and D are not pressed
            cat_rb.linearVelocity = new Vector2(0, cat_rb.linearVelocity.y);
        }


        //Jumps directly up when the space button is pressed
        if((Keyboard.current.spaceKey.wasPressedThisFrame) && (touching_ground == true))
        {
            cat_rb.linearVelocity = new Vector2(cat_rb.linearVelocity.x, jump_height);
            
            //Changes touching_ground to false because it is off the ground
            touching_ground = false;
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
