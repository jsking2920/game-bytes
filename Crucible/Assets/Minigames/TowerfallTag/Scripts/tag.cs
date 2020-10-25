using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class tag : MonoBehaviour
{
    //tracks whether or not a player is tagged
    public bool isTagged = false;

    //sprite for a player that's "it" and not "it"
    public Sprite taggedSprite;
    public Sprite notTaggedSprite;

    public GameObject bomb;

    int playerNumber;

    //this players sprite renderer component
    SpriteRenderer thisSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        //Get the player number from the MovementController script
        playerNumber = this.gameObject.GetComponent<MovementController>().playerNumber;

        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        //sets the player that starts tagged to the appropriate sprite
        if (isTagged)
        {
            thisSpriteRenderer.sprite = taggedSprite;
            bomb.GetComponent<SpriteRenderer>().enabled = true;
        }
        else 
        {
            //Set the player's score to 1 since they're currently winning
            MinigameController.Instance.AddScore(playerNumber, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //when two players collide the untagged player should become tagged
        if (col.gameObject.tag == "Player" && !isTagged)
        {
            thisSpriteRenderer.sprite = taggedSprite;
            isTagged = true;
            MinigameController.Instance.AddScore(playerNumber, -1);
            bomb.GetComponent<SpriteRenderer>().enabled = true;
        }
        //the tagged player should become untagged
        else if (col.gameObject.tag == "Player" && isTagged){
            thisSpriteRenderer.sprite = notTaggedSprite;
            isTagged = false;
            MinigameController.Instance.AddScore(playerNumber, 1);
            bomb.GetComponent<SpriteRenderer>().enabled = false;
        }
 
    }
}
