using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Stop the bullet
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
