using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    //create variable for each sound effect
    public AudioSource PlatformCollision;
    public AudioSource PlayerCollision;

    
    void OnCollisionEnter2D(Collision2D col)
    {
        //play sound when touch wall/floor
        if (col.gameObject.tag == "wall" && col.relativeVelocity.magnitude > 2)
        {
            PlatformCollision.Play();
        }
        //play sound when touch player
        else if (col.gameObject.tag == "Player")
        {
            PlayerCollision.Play();
        }

    }
}
