using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Climb : MonoBehaviour
{
    public GameObject Enviroment;
    public Rigidbody2D playerRigidbody;

    public GameObject player;
    public bool isClimbing;

    public void ClimbUp()
    {
        if (isClimbing)
        {
            DisableEnviromentColliders();
            DisableFreezePlayerY();
            UpdateClimbUp();
        }
    }

    public void ClimbDown()
    {
        if (isClimbing)
        {
            DisableEnviromentColliders();
            DisableFreezePlayerY();
            UpdateClimbDown();
        }
    }

    public void EnableFreezePlayerY()
    {
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void DisableFreezePlayerY()
    {
        playerRigidbody.constraints = RigidbodyConstraints2D.None;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void DisableEnviromentColliders()
    {
        Enviroment.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enviroment"))
        {
            Enviroment = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enviroment"))
        {
            Enviroment.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void UpdateClimbUp()
    {
        playerRigidbody.AddForce(new Vector2(0, 1f), ForceMode2D.Impulse);
        playerRigidbody.gravityScale = 0;
    }

    private void UpdateClimbDown()
    {
        playerRigidbody.AddForce(new Vector2(0, -1f), ForceMode2D.Impulse);
        playerRigidbody.gravityScale = 0;
    }

    public void StopClimbing()
    {
        EnableFreezePlayerY();
        Enviroment.GetComponent<BoxCollider2D>().enabled = true;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.gravityScale = 0;
    }

    public void StopClimbing2()
    {
        Enviroment.GetComponent<BoxCollider2D>().enabled = true;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.gravityScale = 10;
    }
}
