using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public int playerNumber = 1;
    public float jumpForce = 5.0f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Left and right controls
        if (MinigameInputHelper.GetHorizontalAxis(playerNumber) > 0.1)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        } else if (MinigameInputHelper.GetHorizontalAxis(playerNumber) < -0.1)
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }

        //Jump
        if (MinigameInputHelper.IsButton1Down(playerNumber) && rb.velocity.y < 0.001f && rb.velocity.y > -0.001f)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
