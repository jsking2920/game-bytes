using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
        moveSpeed = defaultMoveSpeed;
        jumpForce = defaultJumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement. Maintains y velocity
        inputVector = new Vector3(MinigameInputHelper.GetHorizontalAxis(playerNumber) * moveSpeed, thisRigidBody.velocity.y, 0);
        thisRigidBody.velocity = inputVector;
        
        //Only jumps if the player is not already jumping or falling
        if (MinigameInputHelper.IsButton1Down(playerNumber) && thisRigidBody.velocity.y < 0.001f && thisRigidBody.velocity.y > -0.001f)
        {
            //jump by adding upward force
            thisRigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
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
}
