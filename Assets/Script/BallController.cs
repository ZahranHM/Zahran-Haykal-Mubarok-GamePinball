using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // set max speed nya di inspector
    public float maxSpeed;
    private Rigidbody rig;
    private Transform ballCurrentPosition;
    private Vector3 ballInitPosition;

    public KeyCode resetBallinput;

    public Collider respawn; //Feature 1 Respawn Ball

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        ballCurrentPosition = GetComponent<Transform>();
        ballInitPosition = ballCurrentPosition.transform.position;
    }

    private void Update()
    {
        ReadInput();

        // cek besaran (magnitude) kecepatannya
        if (rig.velocity.magnitude > maxSpeed)
        {
            // kalau melebihi buat vector velocity baru dengan besaran max speed
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }

    private void ReadInput()
    {
        if (Input.GetKey(resetBallinput))
        {
            rig.velocity *= 0;
            ballCurrentPosition.position = ballInitPosition;
        }
    }

    //respawanball
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == respawn)
        {
            rig.velocity *= 0;
            ballCurrentPosition.position = ballInitPosition;

        }
    }
}
