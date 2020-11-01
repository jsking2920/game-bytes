using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Animator animator;
    //scaling factors for movement -- not affected by powerups
    public float defaultMoveSpeed;
    public float defaultJumpForce;
    //scaling facotrs for movement -- affected by powerups
    float moveSpeed;
    float jumpForce;
    //player in control of this object
    public int playerNumber;

    Rigidbody2D thisRigidBody;
    private Vector3 inputVector;
    private Vector3 velVector;

    public bool hasDoubleJump = false;
    bool doubleJumpUsed = false;
    public bool hasJetPack = false;
    public bool hasDash = false;
    public float jetPackVelocity = 15.0f;

    bool tagged;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = defaultMoveSpeed;
        jumpForce = defaultJumpForce;
        hasDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement. Maintains y velocity
        inputVector = new Vector3(MinigameInputHelper.GetHorizontalAxis(playerNumber) * moveSpeed, thisRigidBody.velocity.y, 0);
        thisRigidBody.velocity = inputVector;
        //Jump input
        if (MinigameInputHelper.IsButton1Down(playerNumber))
        {

            //Only jumps if the player is not already jumping or falling
            if (thisRigidBody.velocity.y < 0.01f && thisRigidBody.velocity.y > -0.01f) {
                //jump by adding upward force
                thisRigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                doubleJumpUsed = false;
            }
            //Double jump
            else if (!doubleJumpUsed && hasDoubleJump)
            {
                thisRigidBody.velocity = new Vector3(thisRigidBody.velocity.x, 0, 0);
                thisRigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                doubleJumpUsed = true;
            }

        }

        if (MinigameInputHelper.IsButton2Down(playerNumber))
        {
            //calls dash function
            if (hasDash)
            {
                dash();
            }
        }

        //Jetpack input
        if (MinigameInputHelper.IsButton1Held(playerNumber) && hasJetPack)
        {
            velVector = new Vector3(thisRigidBody.velocity.x, jetPackVelocity, 0);
            thisRigidBody.velocity = velVector;

        }

        //Animation stuff
        tagged = this.gameObject.GetComponent<tag>().isTagged;
        animator.SetBool("tagged", tagged);
        animator.SetFloat("verticalVelocity", thisRigidBody.velocity.y);
        animator.SetFloat("horizontalSpeed", Mathf.Abs(thisRigidBody.velocity.x));
        GameObject bomb = this.gameObject.GetComponent<tag>().bomb;
        //Flip the sprite
        if (thisRigidBody.velocity.x > 0.1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            bomb.transform.localPosition = new Vector3(Mathf.Abs(bomb.transform.localPosition.x), bomb.transform.localPosition.y, bomb.transform.localPosition.z);
        }
        else if(thisRigidBody.velocity.x < -0.1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            bomb.transform.localPosition = new Vector3(-1f*Mathf.Abs(bomb.transform.localPosition.x), bomb.transform.localPosition.y, bomb.transform.localPosition.z);
        }

    }

    public void setMoveSpeed(float spd)
    {
        moveSpeed = spd;
    }
    public void setJumpForce(float frc)
    {
        jumpForce = frc;
    }
    public void dash()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().flipX == false)
        {
            inputVector = new Vector3(150, thisRigidBody.velocity.y, 0);
            thisRigidBody.velocity = inputVector;
        }
        else if (this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
        {
            inputVector = new Vector3(-150, thisRigidBody.velocity.y, 0);
            thisRigidBody.velocity = inputVector;
        }
    }
}
