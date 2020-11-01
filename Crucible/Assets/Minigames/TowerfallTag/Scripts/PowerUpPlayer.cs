using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : MonoBehaviour
{

    //Store current power up; 0 = None, 1 = Speed Boost, 2 = Jump Boost
    public float powerUpSpeedScalar = 2;
    public float powerUpJumpScalar = 2;

    MovementController movementController;

    // Start is called before the first frame update
    void Start()
    {
        //Get the movement controller script
        movementController = this.gameObject.GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPowerUp(int powerUpType)
    {
        switch (powerUpType)
        {
            case 1:
                movementController.setMoveSpeed(movementController.defaultMoveSpeed*powerUpSpeedScalar);
                break;
            case 2:
                movementController.setJumpForce(movementController.defaultJumpForce * powerUpJumpScalar);
                break;
            case 3:
                movementController.hasDoubleJump = true;
                break;
            case 4:
                movementController.hasJetPack = true;
                break;
            case 5:
                movementController.hasDash = true;
                break;
            default:
                break;
        }
    }

    //Reset power ups
    public void cleansePowerUps()
    {
        movementController.setMoveSpeed(movementController.defaultMoveSpeed);
        movementController.setJumpForce(movementController.defaultJumpForce);
        movementController.hasDoubleJump = false;
        movementController.hasJetPack = false;
        movementController.hasDash = false;
    }
}
