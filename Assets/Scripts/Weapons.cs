using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject bullets;
    public GameObject hammerBullets;
    public GameObject bulletSpawns;
    public GameObject display;
    public float speed;
    public float speedback;
    public bool isFiring;
   

    public void Shoot()
    {
        //Add a bullet to the scene
        GetComponent<AudioSource>().Play();
        var transformPosition = bulletSpawns.transform.position;
        var bullet = Instantiate(bullets, transformPosition, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        hammerBullets = bullet;
        try
        {
            hammerBullets.GetComponent<HammerBullet>().orginial = gameObject;
        }
        catch (Exception e)
        {
            //ignored
        }

        
    }

    public void Thunder()
    {
        //Display the thunder
        display.SetActive(true);
    }
    public void BackHammer()
    {
        //Come back to the hammer
        var hammerB = hammerBullets.GetComponent<HammerBullet>();
        hammerB.back = true;
        hammerB.speed = speedback;
        hammerB.target = bulletSpawns.transform;
    }

}
