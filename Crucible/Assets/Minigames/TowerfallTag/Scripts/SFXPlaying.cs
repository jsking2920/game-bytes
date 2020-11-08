using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    //need to define every sound effect used
    public AudioSource Explosion1;
    public AudioSource Pickup1;

    //need to create function for each sound effect used
    public void PlayBang()
    {
        Explosion1.Play ();
    }

    public void PlayBeep()
    {
        Pickup1.Play ();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            //if player touches wall, ground, etc, play this
            Pickup1.Play ();
        }
        else if (col.gameObject.tag == "Player")
        {
            //if player touches other player, play this
            Explosion1.Play ();
        }

    }
}
