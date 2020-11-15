using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    //create variable for each sound effect
    public AudioSource Crash1;
    public AudioSource Menu1;

    //function to play each sound effect
    public void PlayCrash1()
    {
        Crash1.Play();
    }

    public void PlayMenu1()
    {
        Menu1.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //play sound when touch wall/floor
        if (col.gameObject.tag == "wall")
        {
            Crash1.Play();
        }
        //play sound when touch player
        else if (col.gameObject.tag == "Player")
        {
            Menu1.Play();
        }

    }
}
