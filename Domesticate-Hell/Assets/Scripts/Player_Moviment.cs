using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moviment : MonoBehaviour
{
    [SerializeField]float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool crouch = false;
    Rigidbody2D playerRB;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(x * runSpeed, playerRB.velocity.y, 0f);
        playerRB.velocity = move;
    }

}
