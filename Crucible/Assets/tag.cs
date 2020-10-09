using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class tag : MonoBehaviour
{
    private bool isTagged = false;
    Rigidbody2D rb;
    SpriteRenderer sr;
    //string nameOfSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void onCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //nameOfSprite = col.gameObject.GetComponent<SpriteRender>().sprite.name;
        }
    }
    */
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            sr.sprite = (Sprite)Resources.Load<Sprite>("TowerfallTag/TempAssets/WhiteSquare.png");
        }
    }
}
