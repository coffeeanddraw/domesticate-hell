///////////////////////////////////
///// ⚔🦂🐾BAT GIRL🐾🦂⚔ /////
///////////////////////////////////
//////DOMESTICATE HELL - 2019//////
///////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour
{
    Rigidbody2D rgbd2D;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float changeTime = 3.0f;

    private float timer;
    private int direction = 1;

    void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
    }

    // * Run Finite State Machine *// 
    private void Idle()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = rgbd2D.position;

        position.x = position.x + Time.deltaTime * speed * direction;

        rgbd2D.MovePosition(position);
    }

}
