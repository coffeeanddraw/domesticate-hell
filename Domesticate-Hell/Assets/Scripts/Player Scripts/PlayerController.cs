using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 0;

    private Rigidbody2D playerRB2D = null;

    private static bool playerAllowedToMove = true; 

    public static bool PlayerAllowedToMove
    {
        get { return playerAllowedToMove; }
        set { playerAllowedToMove = value; }
    }

    void Awake()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAllowedToMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector2 position = transform.position;
            position.x = position.x + playerSpeed * horizontalInput * Time.deltaTime;
            position.y = position.y + playerSpeed * verticalInput * Time.deltaTime;

            playerRB2D.MovePosition(position);
        } 
    }
}
