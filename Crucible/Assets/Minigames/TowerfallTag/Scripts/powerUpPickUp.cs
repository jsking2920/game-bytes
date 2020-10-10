using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpPickUp : MonoBehaviour
{
    //amount that playes speed is boosted by
    public float speedBoost = 10.0f;

    //when something collides with this trigger, this function is called
    void OnTriggerEnter2D(Collider2D col)
    {
        //destorys powerup when a player picks it up and bumps their speed
        if (col.gameObject.tag == "Player") { 
            MovementController thisMovementController = col.gameObject.GetComponent<MovementController>();
            thisMovementController.moveSpeed += speedBoost;

            Destroy(this.gameObject);
        }
  
    }
}
