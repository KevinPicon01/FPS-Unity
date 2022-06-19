using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttrackObject : MonoBehaviour
{
    public bool isAtrrack;
    public bool isOrbit;

    [Header("Atraccion")]
    [SerializeField] private float speed;
    [SerializeField] public GameObject target;
    
    [Header("Orbita")]
    [SerializeField] private float speedOrbit;
    [SerializeField] private float radius;
    private Transform orbitingObject;
    private float angle;
    private float rec;
    private int x,y,z,w;

    private int RandomNumber()
    {
        //Random number -1 or 1
        x = Random.Range(0, 2);
        if (x == 0)
        {
            x = -1;
        }
        return x;
    }
    // Update is called once per frame
    void Update()
    { 
        var pos = new Vector3(1,0,1);
        if (isAtrrack)
        {
            float step = speed * Time.deltaTime;
            try
            {
                //Move objects to target
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position+pos, step);
            }
            catch (Exception e)
            {
                isAtrrack = false;
            }            
            if (transform.position == target.transform.position+pos)
            {
                isAtrrack = false;
                orbitingObject = target.transform;
                //Axie positive or negative
                x = RandomNumber();
                y = RandomNumber();
                z = RandomNumber();
                w = Random.Range(0, 3);
                isOrbit = true;
            }
        }
        if (!isOrbit) return;
        rec = 1 * speedOrbit;
        angle += rec * Mathf.Deg2Rad;
    }

    private void LateUpdate()
    {
        if (!isOrbit) return;
        var pos = new Vector3(x, y, z);
        //Axis of rotation
        if(w==0)
        {
            pos = new Vector3(Mathf.Cos(angle) * radius * x, Mathf.Sin(angle) * radius*y, Mathf.Cos(angle) * radius*z);
        }
        else if(w==1)
        {
            pos = new Vector3(Mathf.Sin(angle) * radius*x, Mathf.Cos(angle) * radius*y, Mathf.Cos(angle) * radius*z);
        }
        else
        {
            pos = new Vector3(Mathf.Cos(angle) * radius*x, Mathf.Cos(angle) * radius*y, Mathf.Sin(angle) * radius*z);
        }
        try
        {
            transform.position = orbitingObject.position + pos;
        }
        catch (Exception e)
        {
            isOrbit = false;
        }
    }
}
