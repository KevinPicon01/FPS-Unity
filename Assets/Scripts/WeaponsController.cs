using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots;
    [SerializeField] public GameObject[] weapons;
    [SerializeField] public GameObject[] weaponsAnim;
    [SerializeField] private AudioClip[] weaponsSounds;
    public int status = 0;
    private bool secure = true;
    private float lastShot = 0;

    private void Update()
    {
        //Player Shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) && status > 0 && secure)
        {
            Shoot();
            secure = false;
            lastShot = Time.time;
        }
        if (Time.time - lastShot > timeBetweenShots)secure = true;
    }
    
    // Shoot function
    private void Shoot()
    {
        var weapon = weapons[status - 1].GetComponent<Weapons>();
        if (status == 1)
        {
            weapon.Shoot();
        }
        else if (status == 2)
        {
            weapon.Shoot();
        }
        else if (status == 3)
        {
            if (!weapon.isFiring)
            {
                weapon.GetComponent<AudioSource>().Play();
                weapons[status - 1].SetActive(false);
                weapon.isFiring = true;
                weapon.Shoot();
            }else
            {
                weapon.BackHammer();
            }
            
        }
    }
    // Desable Weapons Animations
    public void DisableWeaponsAnima(int index)
    {
        weaponsAnim[index].SetActive(false);
    }
    

    public void DisableWeapons(int index)
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
        if (index == 3)
        {
            GetComponent<AudioSource>().Stop();
            status = 0;
            return;
        }
        DisableWeaponsAnima(index);
        weapons[index].SetActive(true);
        GetComponent<AudioSource>().clip = weaponsSounds[index];
        GetComponent<AudioSource>().Play();
        if (index==2)
        {
            GetComponent<AudioSource>().loop = true;
        }
        else
        {
            GetComponent<AudioSource>().loop = false;
        }
    }
}
    
   
    
