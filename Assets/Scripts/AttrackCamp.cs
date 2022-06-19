using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrackCamp : MonoBehaviour
{
    private bool secure;
    public GameObject attacker;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Atraible")
        {
             other.GetComponent<AttrackObject>().isAtrrack = true;
            other.GetComponent<AttrackObject>().target = gameObject;
            attacker = other.gameObject;
            secure = true;
        }
    }
    public void Update()
    {
        if (secure)
        {
            attacker.GetComponent<AttrackObject>().target = gameObject;
            if (attacker.GetComponent<AttrackObject>().isAtrrack)
            {
                secure = false;
            }
        }
    }
}
