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

    //this players sprite renderer component
    SpriteRenderer thisSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        //sets the player that starts tagged to the appropriate sprite
        if (isTagged)
        {
            thisSpriteRenderer.sprite = taggedSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //when two players collide the untagged player should become tagged
        if (col.gameObject.tag == "Player" && !isTagged)
        {
            thisSpriteRenderer.sprite = taggedSprite;
            isTagged = true;
        }
        //the tagged player should become untagged
        else if (col.gameObject.tag == "Player" && isTagged){
            thisSpriteRenderer.sprite = notTaggedSprite;
            isTagged = false;
        }
 
    }
}
