// Cattatonicat 2019 
// Domesticate Hell

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{

    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float changeTime = 3.0f;

    private Transform petLocation;

    private float timer;
    private int direction = 1;

    private bool colliding = false;

    private Rigidbody2D petRB2D;

    void Awake()
    {
        petRB2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        petLocation = GetComponent<Transform>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
    }

    // * Run Finite State Machine *// 
    void Idle()
    {
        Vector2 position = petRB2D.position;

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        petLocation.position = new Vector2(petLocation.position.x + Time.deltaTime * speed * direction, 0);

        //Vector2 position = petLocation.position;

        //petLocation.x = petLocation.x + Time.deltaTime * speed * direction; 

        //position.x = position.x + Time.deltaTime * speed * direction;

        //rgbd2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        colliding = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        colliding = false;
    }

}
