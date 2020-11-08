using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpPlayer : MonoBehaviour
{

    //Store current power up; 0 = None, 1 = Speed Boost, 2 = Jump Boost
    public float powerUpSpeedScalar = 2;
    public float powerUpJumpScalar = 2;
    public TextMeshProUGUI powerUpText;


    MovementController movementController;
    int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        //Get the movement controller script
        movementController = this.gameObject.GetComponent<MovementController>();
        playerNumber = movementController.playerNumber;
        powerUpText.SetText("");
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
                movementController.setMoveSpeed(movementController.defaultMoveSpeed * powerUpSpeedScalar);
                powerUpText.SetText("Speed boost!");
                break;
            case 2:
                movementController.setJumpForce(movementController.defaultJumpForce * powerUpJumpScalar);
                powerUpText.SetText("Jump Boost!");
                break;
            case 3:
                movementController.hasDoubleJump = true;
                powerUpText.SetText("Double Jump!");
                break;
            case 4:
                movementController.hasJetPack = true;
                powerUpText.SetText("Jet pack!");
                break;
            case 5:
                movementController.hasDash = true;
                powerUpText.SetText("Dash!");
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
        powerUpText.SetText("");
    }
}
