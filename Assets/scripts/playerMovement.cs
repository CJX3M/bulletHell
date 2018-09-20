using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 0.0f;

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = movement * speed;
    }
   
}
